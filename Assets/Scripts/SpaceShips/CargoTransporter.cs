using UnityEngine;
using System.Collections;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class CargoTransporter : Spaceship
    {
        private CargoHandler _cargoHandler = null;

        // временные переменные здесь:
        private Transform _tempTarget = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _tempTarget = GetTarget();

            if (collision.transform == _tempTarget)
            {
                var tempShipReceiver = _tempTarget.GetComponent<CargoLoaderForShips>();
                if (tempShipReceiver != null)
                {
                    tempShipReceiver.AcceptShip(_cargoHandler);
                }
            }

            _tempTarget = null;
        }

        protected override void DoAwakeWork()
        {
            base.DoAwakeWork();
            _cargoHandler = GetComponent<CargoHandler>();
        }
    }
}