using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships
{
    public class Spaceship : MonoBehaviour, IPooledObject, IDeparturePlaceKeeper, IFlying
    {
        public IFlying Flying { get; private set; }
        public IDeparturePlaceKeeper DeparturePlaceKeeper { get; private set; }

        public ObjectPooler.ObjectInfo.ObjectType Type => type;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type = ObjectPooler.ObjectInfo.ObjectType.CargoTransporter;
        [SerializeField] private Transform _target = null;

        private Transform _departureObject = null;
        private Vector3 _targetPoint = Vector3.zero;
        private bool _canMove = true;

        private void Awake()
        {
            DoAwakeWork();
        }

        private void Start()
        {
            DoStartWork();
        }

        private void Update()
        {
            UpdateTargetPoint();
        }

        #region GettersSetters
        public void SetTarget(Transform target)
        {
            this._target = target;
        }

        public Transform GetTarget()
        {
            return _target;
        }

        public void SetDepartureObject(Transform departureObject)
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
        #endregion

        public void UpdateTargetPoint()
        {
            if (_target != null)
            {
                _targetPoint = _target.position;
            }
        }

        public bool IsCanMove()
        {
            return _canMove;
        }

        public void SetCanMove(bool value)
        {
            _canMove = value;
        }

        protected virtual void DoAwakeWork()
        {
            Flying = GetComponent<IFlying>();
            DeparturePlaceKeeper = GetComponent<IDeparturePlaceKeeper>();
        }

        protected virtual void DoStartWork() { }
    }
}
