using System;
using UnityEngine;
using PlanetsColony.Spaceships.Components;

namespace PlanetsColony.Spaceships
{
    public class Spaceship : MonoBehaviour, IPooledObject, IDeparturePlaceKeeper, IFlying
    {
        public IFlying Flying { get; private set; }
        public IDeparturePlaceKeeper DeparturePlaceKeeper { get; private set; }

        public ObjectPooler.ObjectInfo.ObjectType Type => type;
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type = ObjectPooler.ObjectInfo.ObjectType.CargoTransporter;
        [SerializeField] private Transform _target = null;
        [Header("Implements IWheel.")]
        [SerializeField] private GameObject _spaceshipWheel = null;
        [Header("Implements ISpaceshipMotor.")]
        [SerializeField] private GameObject _spaceshipMotor = null;

        private IWheel _wheel = null;
        private IMotor _motor = null;
        private Transform _transform = null;
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
            _wheel.RotateTo(_transform, _targetPoint);
            UpdateTargetPoint();
        }

        private void FixedUpdate()
        {
            if (IsCanMove())
            {
                _motor.SetLocalVelocity();
            }
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
            _transform = transform;
            Flying = GetComponent<IFlying>();
            DeparturePlaceKeeper = GetComponent<IDeparturePlaceKeeper>();
            _wheel = _spaceshipWheel.GetComponent<IWheel>();
            if (_wheel == null)
            {
                throw new NullReferenceException("No component that implements the IWheel interface was found.");
            }
            _motor = _spaceshipMotor.GetComponent<IMotor>();
            if (_motor == null)
            {
                throw new NullReferenceException("No component that implements the IMotor interface was found.");
            }
        }

        protected virtual void DoStartWork() { }
    }
}
