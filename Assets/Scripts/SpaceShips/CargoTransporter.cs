using UnityEngine;
using System.Collections;
using PlanetsColony.Levels;
using System;
using PlanetsColony.Improvements;
using PlanetsColony.Cargos;

namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(CargoHandler), typeof(Rigidbody2D), typeof(Collider2D))]
    public class CargoTransporter : Spaceship
    {
        private CargoHandler _cargoHandler = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = GetTarget();
            if (collision.transform == tempTarget)
            {
                var tempShipReceiver = tempTarget.GetComponent<SpaceshipsReceiver>();
                if (tempShipReceiver != null)
                {
                    tempShipReceiver.AcceptShip(_cargoHandler);
                }
            }
        }

        protected override void DoAwakeWork()
        {
            base.DoAwakeWork();
            _cargoHandler = GetComponent<CargoHandler>();
        }

        protected override void DoStartWork()
        {
            base.DoStartWork();
        }
    }
}