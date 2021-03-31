using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    [RequireComponent(typeof(CameraDistance))]
    public class CameraMovement : MonoBehaviour
    {
        public UnityEvent OnMoved;

        [SerializeField] private float _speed = 1f;
        [SerializeField] private bool _useJoystic = false;
        [SerializeField] private Joystick _joystick;

        private Transform _transform;
        private CameraDistance _cameraDistance;

        private Vector2 _offset = new Vector2(0, 0);
        private Vector2 _zeroOffset = Vector2.zero;
        private float _speedMultiplier;
        private float _horizontal = 0;
        private float _vertical = 0;
        private bool _ignoreAxis = false;

        private void Awake()
        {
            _transform = transform;
            _cameraDistance = GetComponent<CameraDistance>();

            if (_useJoystic)
            {
                if (_joystick == null)
                {
                    throw new ArgumentNullException("Поле Joystick не установлено!");
                }
                else
                {
                    _joystick = _joystick.GetComponent<Joystick>();
                }
            }
        }

        private void Start()
        {
            _transform = transform;
            _speedMultiplier = CalculateSpeedMultiplier();
        }

        private void Update()
        {
            Move();
            _ignoreAxis = false;
        }

        private void Move()
        {
            _offset = GetInput() * _speedMultiplier;

            if (_offset != _zeroOffset)
            {
                _transform.position += (Vector3)_offset;
                OnMoved.Invoke();
            }
            CalculateSpeedMultiplier();
        }

        private Vector2 GetInput()
        {
            if (_useJoystic)
            {
                _horizontal = _joystick.Horizontal;
                _vertical = _joystick.Vertical;
            }
            else
            {
                _horizontal = Input.GetAxis("Horizontal");
                _vertical = Input.GetAxis("Vertical");
            }

            return new Vector2(_horizontal, _vertical);
        }

        private float CalculateSpeedMultiplier()
        {
            return _speedMultiplier = _speed * Mathf.Sqrt(_cameraDistance.GetDistanceToSun()) / 5;
        }


        //ToDo: ПЕРЕПИШИ ЭТО ДЕРЬМО::::::
        
        public void Up()
        {
            _ignoreAxis = true;
            _vertical = _speedMultiplier;
        }
        public void Down()
        {
            _ignoreAxis = true;
            _vertical = -_speedMultiplier;
        }
        public void Left()
        {
            _ignoreAxis = true;
            _horizontal = -_speedMultiplier;
        }
        public void Right()
        {
            _ignoreAxis = true;
            _horizontal = _speedMultiplier;
        }
    }
}