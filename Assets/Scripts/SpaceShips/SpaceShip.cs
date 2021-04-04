using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Spaceship : MonoBehaviour, IPooledObject
    {
        public ObjectPooler.ObjectInfo.ObjectType Type => type;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type = ObjectPooler.ObjectInfo.ObjectType.CargoTransporter;
        [SerializeField] private Transform _target = null;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _rotationSpeed = 0.1f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;
        private Transform _departureObject = null;
        private float _distanceDelta = 0f;
        private float _tempZRotation = 0f;
        private bool _canMove = true;
        private Vector2 _tempVelocity = Vector2.zero;
        private Vector3 _tempDifference = Vector3.zero;
        private Vector3 _tempLocalVelocity = Vector3.zero;
        private Vector3 _tempTargetPosition = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            _distanceDelta = _speed * Time.deltaTime;
            DoAwakeWork();
        }

        private void Update()
        {
            CheckCanMove();
            RotateTo(_tempTargetPosition);
        }


        private void FixedUpdate()
        {
            CheckCanMove();

            _tempVelocity.Set(0, CalculateDistanceDelta());
            SetLocalVelocity(_tempVelocity);
        }

        #region MoveWork
        private void CheckCanMove()
        {
            if (!_canMove)
            {
                return;
            }

            if (_target != null)
            {
                _tempTargetPosition = _target.position;
            }
        }

        private void RotateTo(Vector3 target)
        {
            _tempDifference = target - _transform.position;
            _tempZRotation = Mathf.Atan2(_tempDifference.y, _tempDifference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(_tempZRotation - 90, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
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
        #endregion

        #region GettersSetters
        internal void SetTarget(Transform target)
        {
            this._target = target;
        }
        public Transform GetTarget()
        {
            return _target;
        }

        internal void SetDepartureObject(Transform departureObject)
        {
            this._departureObject = departureObject;
        }

        public Transform GetDepartureObject()
        {
            return _departureObject;
        }
        public void SetDepartureObjectAsTarget()
        {
            _target = _departureObject;
        }

        public void SetCanMove(bool canMove)
        {
            this._canMove = canMove;
        }
        #endregion

        protected virtual void DoAwakeWork()
        {

        }
    }
}
