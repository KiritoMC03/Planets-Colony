using PlanetsColony.Improvements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(Spaceship))]
    public class SpaceshipMotor : MonoBehaviour
    {
        [SerializeField] protected float _baseDevelopedSpeed = 1f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;
        private Spaceship _spaceship = null;
        private float _calculatedSpeed = 0f;
        private float _speedImprovement = 0f;
        private Vector2 _finalVelocity = Vector2.zero;
        private Vector3 _tempLocalVelocity = Vector3.zero;

        private void Awake()
        {
            _calculatedSpeed = _baseDevelopedSpeed * Time.deltaTime;
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            _spaceship = GetComponent<Spaceship>();

            if(_spaceship == null)
            {
                throw new NullReferenceException("Spaceship component not found.");
            }
        }

        private void FixedUpdate()
        {
            if (_spaceship.IsCanMove())
            {
                _finalVelocity.Set(0, CalculateDistanceDelta());
                SetLocalVelocity(_finalVelocity);
            }
        }

        private float CalculateDistanceDelta()
        {
            return _calculatedSpeed = (_baseDevelopedSpeed + _speedImprovement) * Time.fixedDeltaTime;
        }

        private void SetLocalVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = Vector2.zero;

            _tempLocalVelocity = _transform.InverseTransformDirection(_rigidbody.velocity);
            _tempLocalVelocity = velocity;
            _rigidbody.velocity = _transform.TransformDirection(_tempLocalVelocity);
        }

        internal void SetSpeedImprovement(float value)
        {
            _speedImprovement = value;
        }

        internal void TrySetSpeedImprovement(float value)
        {
            if (value < 0f) return;
            _speedImprovement = value;
        }

        public float GetDevelopedSpeed()
        {
            return _baseDevelopedSpeed;
        }
    }
}