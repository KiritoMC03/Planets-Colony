using UnityEngine;
using System.Collections;
using PlanetsColony.Levels;
using System;
using PlanetsColony.Improvements;
using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(SpaceshipCargoHandler), typeof(Rigidbody2D), typeof(Collider2D))]
    public class CargoTransporter : Spaceship
    {
        private Transform _transform = null;
        private SpaceshipCargoHandler _cargoHandler = null;

        private void Awake()
        {
            base.DoAwakeWork();
            _transform = transform;
            _cargoHandler = GetComponent<SpaceshipCargoHandler>();
            if (_cargoHandler == null)
            {
                throw new NullReferenceException("SpaceshipCargoHandler component not found.");
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