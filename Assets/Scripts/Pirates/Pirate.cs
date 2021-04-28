using UnityEngine;
using System.Collections;
using PlanetsColony.Spaceships;
using PlanetsColony.Cargos.CargoHandlingByShip;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Factories;
using System;

namespace PlanetsColony.Pirates
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Pirate : MonoBehaviour, IFlying, IPirate
    {
        [SerializeField] private float _speed = 100f;
        [Header("Implements IWheel.")]
        [SerializeField] private GameObject _spaceshipWheel = null;
        [Header("Implements IMotor.")]
        [SerializeField] private GameObject _spaceshipMotor = null;
        private IWheel _wheel = null;
        private IMotor _motor = null;
        private Rigidbody2D _rigidbody = null;
        private Transform _target = null;
        private Transform _transform = null;
        private Vector2 _spawnPosition = Vector2.zero;
        private Vector3 _localVelocity = Vector3.zero;
        private List<ICargo> _cargos = null;
        private bool _escape = false;

        private void Awake()
        {
            InitFields();
        }

        private void FixedUpdate()
        {
            if (_escape)
            {
                Move();
                _wheel.RotateTo(_transform, _spawnPosition);
            }
            else
            {
                if (_target != null)
                {
                    Move();
                    _wheel.RotateTo(_transform, _target.position);
                }
            }
        }

        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var factory = collision.gameObject.GetComponent<IFactory>();
            if (factory != null)
            {
                Debug.Log("Here");
                //factory.SendCargo()
                factory.IsRobbed = true;
                Escape();
            }
        }
        */

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var factory = collision.gameObject.GetComponent<IFactory>();
            if (factory != null)
            {
                _rigidbody.velocity = Vector2.zero;
                factory.IsRobbed = true;
                Escape();
            }
        }

        public void SetSpawnPosition(Vector2 position)
        {
            _spawnPosition = position;
        }

        public void Escape()
        {
            _escape = true;
        }

        public void Move()
        {
            _motor.SetLocalVelocity();
        }

        public bool IsCanMove()
        {
            throw new System.NotImplementedException();
        }

        public void SetCanMove(bool value)
        {
            throw new System.NotImplementedException();
        }

        public void StealCargo(ICargo cargo)
        {
            _cargos.Add(cargo);
        }

        public void TryStealCargo(ICargo cargo)
        {
            if (_cargos == null)
            {
                _cargos = new List<ICargo>();
            }
            _cargos.Add(cargo);
        }

        public void StealCargos(List<ICargo> cargos)
        {
            _cargos = cargos;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public Transform GetTarget()
        {
            return _target;
        }

        private void InitFields()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();

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