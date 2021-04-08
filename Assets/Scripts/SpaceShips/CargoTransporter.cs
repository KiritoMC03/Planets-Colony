using UnityEngine;
using System.Collections;
using PlanetsColony.Levels;
using System;
using PlanetsColony.Improvements;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class CargoTransporter : Spaceship
    {
        [SerializeField] private SpriteRenderer _shipSprite = null;
        private CargoHandler _cargoHandler = null;
        private float _speedImprovement = 0f;
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
            CargoTransporterSpeedImprovement.Instance.OnLevelUp.AddListener(SetSpeedImprovement);
            UpdateLevelSprite();
        }

        public void UpdateLevelSprite()
        {
            _shipSprite.sprite = SpaceshipsLevelling.Instance.GetCurrentSprite();
        }

        protected override float CalculateDistanceDelta()
        {
            return base.CalculateDistanceDelta() + _speedImprovement;
        }

        private void SetSpeedImprovement()
        {
            _speedImprovement = CargoTransporterSpeedImprovement.GetImprovedSpeed(_speed);
        }

        private void OnEnable()
        {
            SetSpeedImprovement();
        }
    }
}