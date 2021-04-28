using UnityEngine;
using System.Collections;
using System;
using PlanetsColony.Spaceships;

namespace PlanetsColony.Pirates
{
    [RequireComponent(typeof(IPirate))]
    public class PirateMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 100f;
        [Header("Implements IWheel.")]
        [SerializeField] private GameObject _spaceshipWheel = null;
        [Header("Implements IMotor.")]
        [SerializeField] private GameObject _spaceshipMotor = null;
        private IPirate _pirate = null;
        private IWheel _wheel = null;
        private IMotor _motor = null;
        private Transform _transform = null;

        private void Awake()
        {
            InitFields();
        }

        private void FixedUpdate()
        {
            if (_pirate.IsEscape())
            {
                Move();
                _wheel.RotateTo(_transform, _pirate.GetSpawnPosition());
            }
            else
            {
                if (_pirate.GetTarget() != null)
                {
                    Move();
                    _wheel.RotateTo(_transform, _pirate.GetTarget().position);
                }
            }
        }

        public void Move()
        {
            _motor.SetLocalVelocity();
        }

        private void InitFields()
        {
            _transform = transform;
            try
            {
                _pirate = GetComponent<IPirate>();
            }
            catch
            {
                throw new NullReferenceException("No component that implements the IFactoryLevel interface was found.");
            }

            try
            {
                _wheel = _spaceshipWheel.GetComponent<IWheel>();
            }
            catch
            {
                throw new NullReferenceException("Wheel field must not be null.");
            }

            try
            {
                _motor = _spaceshipMotor.GetComponent<IMotor>();
            }
            catch
            {
                throw new NullReferenceException("No component that implements the IMotor interface was found.");
            }
        }
    }
}