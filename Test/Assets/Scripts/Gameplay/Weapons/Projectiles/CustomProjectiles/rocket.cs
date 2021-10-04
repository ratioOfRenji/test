using System.Collections;
using System.Collections.Generic;
using Gameplay.Weapons.Projectiles;
using UnityEngine;
namespace Gameplay.Weapons.Projectiles
{

    public class rocket : Projectile
    {
        [SerializeField]
        private GameObject explosionVFX;
        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                
                Instantiate(explosionVFX, this.transform.position, this.transform.rotation);
                 Destroy(gameObject);
               
              
            }
          
        }
    }
}
