using UnityEngine;
using System.Collections;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class CargoTransporter : Spaceship
    {
        private Spaceship _spaceship = null;
        private CargoHandler _cargoHandler = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = _spaceship.GetTarget();

            if (collision.transform == tempTarget)
            {
                var tempShipReceiver = tempTarget.GetComponent<CargoLoaderForShips>();
                if (tempShipReceiver != null)
                {
                    tempShipReceiver.AcceptShip(_cargoHandler);
                }
            }
        }

        protected override void DoAwakeWork()
        {
            base.DoAwakeWork();
            _spaceship = this;
            _cargoHandler = GetComponent<CargoHandler>();
        }
    }
}