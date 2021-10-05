using Gameplay.ShipSystems;
using UnityEngine;
using Gameplay.Helpers;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private SpriteRenderer _representation;
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            //обнуление скорости, если корабль достиг ограничвающей позиции
            float direction;
            direction = Input.GetAxis("Horizontal");
            if (transform.position.x > GameAreaHelper.rightBound(transform, _representation.bounds))
            {
              if(direction > 0)
                {
                    direction = 0;
                }
            }
            if (transform.position.x < GameAreaHelper.leftBound(transform, _representation.bounds))
            {
                if (direction < 0)
                {
                    direction = 0;
                }
            }


            movementSystem.LateralMovement(direction* Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
