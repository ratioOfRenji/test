using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
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

        //private void OnEnable()
        //{
        //   
        //}
        public void ApplyDamage(IDamageDealer damageDealer)
        {
            hp -= damageDealer.Damage;
            if (_battleIdentity == UnitBattleIdentity.Ally)
            {
                _healthBar.minusHeart();
            }

            if (hp<= 0)
            { 
                if(_battleIdentity == UnitBattleIdentity.Enemy)
                {
                 _score.addScore();
                }
                Destroy(gameObject);
            }
           
        }

    }
}
