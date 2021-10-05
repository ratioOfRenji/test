using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IHealable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;


        private score _score;

        private HealthBar _healthBar;
        [SerializeField]
        private BonusSpawner _bonusSpawner;

        [SerializeField]
        private float hp;

       
        

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
           _score = GameObject.FindGameObjectWithTag("ScorePannel").GetComponent<score>();
            _healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();

        }

        
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            hp -= damageDealer.Damage;
            if (_battleIdentity == UnitBattleIdentity.Ally)
            {
                // наносит урон игроку
                _healthBar.minusHeart();
            }

            if (hp<= 0)
            { 
                if(_battleIdentity == UnitBattleIdentity.Enemy)
                {
                    //начисляет очки за сбитого врага
                 _score.addScore();
                    // вызывает метод, который с шансом ы 10% создает бонус, востанавливающий здоровье
                  _bonusSpawner.InitBonus(this.transform);
                }
                Destroy(gameObject);
            }
           
        }

        //реалиация инерфейса. метод вызывется в HeartBonus и восполняет здоровье
        public void heal(float _hp)
        {
            if(hp< 300)
            {
 // восполнение здоровья
            hp += _hp;
            // приводит UI в соответствие с реальным здоровьем
            _healthBar.plusHeart();
            }
           
        }
    }
}
