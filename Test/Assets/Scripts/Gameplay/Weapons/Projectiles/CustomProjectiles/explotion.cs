using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public class explotion : Projectile
    {
        protected override void Move(float speed)
        {
            transform.Translate(Vector3.zero);
        }
        // раюотает так же как обычный патрон, но во всей области взрыва, пока он сущкствует.
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null
                && damagableObject.BattleIdentity != BattleIdentity)
            {

                damagableObject.ApplyDamage(this);

                // начинает отсчет до уничтожения взрыва
                StartCoroutine(waitBeforeStop());

            }
            IEnumerator waitBeforeStop()
            {
               
                yield return new WaitForSeconds(0.9f);
               Destroy(gameObject);
            }
        }
    }

}
