using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay.Weapons.Projectiles
{
    public class HeartBonus : MonoBehaviour
    {
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var healableObject = other.gameObject.GetComponent<IHealable>();

            if (healableObject != null
               )
            {
                //вызывает метод интерфейса IHealable
                healableObject.heal(100);
                Destroy(gameObject);

               

            }
            
        }
    }
}
