using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private Transform _target = null;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _rotationSpeed = 0.1f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;

        private float _distanceDelta = 0f;
        private float _tempZRotation = 0f;
        private Vector2 _tempVelocity = Vector2.zero;
        private Vector3 _tempDifference = Vector3.zero;
        private Vector3 _tempLocalVelocity = Vector3.zero;
        private Vector3 _tempTargetPosition = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            _distanceDelta = _speed * Time.deltaTime;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_target != null)
            {
                _tempTargetPosition = _target.position;
            }

            _tempVelocity.Set(0, CalculateDistanceDelta());
            SetLocalVelocity(_tempVelocity);
            RotateTo(_tempTargetPosition);
        }

        private void RotateTo(Vector3 target)
        {
            _tempDifference = target - _transform.position;
            _tempZRotation = Mathf.Atan2(_tempDifference.y, _tempDifference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(_tempZRotation - 90, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed);
        }
        
        private float CalculateDistanceDelta()
        {
            return _distanceDelta = _speed * Time.deltaTime;
        }

        private void SetLocalVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = Vector2.zero;

            _tempLocalVelocity = _transform.InverseTransformDirection(_rigidbody.velocity);
            _tempLocalVelocity = velocity;
            _rigidbody.velocity = _transform.TransformDirection(_tempLocalVelocity);
        }

        #region GettersSetters
        internal void SetTarget(Transform target)
        {
            this._target = target;
        }
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform == _target)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform == _target)
            {
                Destroy(gameObject);
            }
        }
    }
}
