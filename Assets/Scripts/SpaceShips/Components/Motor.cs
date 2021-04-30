using PlanetsColony.Improvements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships.Components
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Motor : MonoBehaviour, IMotor
    {
        [SerializeField] protected float _baseDevelopedSpeed = 1f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;
        private float _calculatedSpeed = 0f;
        private float _speedImprovement = 0f;
        private Vector2 _finalVelocity = Vector2.zero;
        private Vector3 _tempLocalVelocity = Vector3.zero;

        private void Awake()
        {
            _calculatedSpeed = _baseDevelopedSpeed * Time.deltaTime;
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetLocalVelocity()
        {
            _finalVelocity.Set(0, CalculateDistanceDelta());

            _rigidbody.velocity = Vector2.zero;
            _tempLocalVelocity = _transform.InverseTransformDirection(_rigidbody.velocity);
            _tempLocalVelocity = _finalVelocity;
            _rigidbody.velocity = _transform.TransformDirection(_tempLocalVelocity);
        }

        private float CalculateDistanceDelta()
        {
            return _calculatedSpeed = (_baseDevelopedSpeed + _speedImprovement) * Time.fixedDeltaTime;
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