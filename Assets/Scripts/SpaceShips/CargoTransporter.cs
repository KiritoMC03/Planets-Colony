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
        [SerializeField] private SpriteRenderer _shipSprite = null;
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
            if(_shipSprite == null)
            {
                throw new Exception();
            }
        }

        protected override void DoStartWork()
        {
            base.DoStartWork();
            SpaceshipsLevelling.Instance.OnSpaceshipsLevelUp.AddListener(UpdateLevelSprite);
            UpdateLevelSprite();
        }

        public void UpdateLevelSprite()
        {
            _shipSprite.sprite = SpaceshipsLevelling.Instance.GetCurrentSprite();
        }
    }
}