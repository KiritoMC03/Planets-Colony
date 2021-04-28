using PlanetsColony.Improvements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(Motor))]
    public class SpaceshipMotorImprover : MonoBehaviour
    {
        private Motor _spaceshipMotor = null;
        private float _speedImprovement = 0f;

        private void Awake()
        {
            _spaceshipMotor = GetComponent<Motor>();

            if (_spaceshipMotor == null)
            {
                throw new NullReferenceException("SpaceshipMotor component not found.");
            }
        }

        private void Start()
        {
            CargoTransporterSpeedImprovement.Instance.OnLevelUp.AddListener(SetSpeedImprovement);
        }

        private void SetSpeedImprovement()
        {
            _speedImprovement = CargoTransporterSpeedImprovement.GetImprovedSpeed(_spaceshipMotor.GetDevelopedSpeed());
            _spaceshipMotor.SetSpeedImprovement(_speedImprovement);
        }

        private void OnEnable()
        {
            SetSpeedImprovement();
        }
    }
}