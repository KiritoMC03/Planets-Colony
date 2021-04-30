using System;
using UnityEngine;
using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Spaceships.Types
{
    [RequireComponent(typeof(ISpaceshipCargoHandler), typeof(Rigidbody2D), typeof(Collider2D))]
    public class CargoTransporter : Spaceship, ICargoTransporter
    {
        private Transform _transform = null;
        private ISpaceshipCargoHandler _cargoHandler = null;

        private void Awake()
        {
            base.DoAwakeWork();
            _transform = transform;
            _cargoHandler = GetComponent<ISpaceshipCargoHandler>();
            if (_cargoHandler == null)
            {
                throw new NullReferenceException("No component that implements the ISpaceshipCargoHandler interface was found.");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = GetTarget();
            if (collision.transform == tempTarget)
            {
                var tempShipReceiver = tempTarget.GetComponent<ISpaceshipsReceiver>();
                if (tempShipReceiver != null)
                {
                    tempShipReceiver.AcceptShip(_cargoHandler);
                }
            }
        }

        protected override void DoStartWork()
        {
            base.DoStartWork();
        }

        public void SetUnityPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}