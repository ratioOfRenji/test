using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{
    [SerializeField]
    private float xAxisMovementAmmount;

    private bool timeToChangeDirection = true;
    [SerializeField]
    private Vector2 _fireDelay;

    private bool _fire = true;
    
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
        // реализация движения по оси х. Если xAxisMovementAmmount равен 0, враг не будет двигаться по оси х.
        movementSystem.LateralMovement(xAxisMovementAmmount * Time.deltaTime);
        if(timeToChangeDirection)
        {
         StartCoroutine(waitBeforeStop());
        }
      
        IEnumerator waitBeforeStop()
        {
            timeToChangeDirection = false;
         
            yield return new WaitForSeconds(0.9f);
            xAxisMovementAmmount = xAxisMovementAmmount * -1;
            timeToChangeDirection = true;
        }
      
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
