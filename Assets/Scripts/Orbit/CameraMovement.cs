using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CameraRange))]
public class CameraMovement : MonoBehaviour
{
    public UnityEvent Moved;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _scrollSpeed = 1f;
    [SerializeField] private bool _forwardOnZ;
    [SerializeField] private float _minCameraHeight = 0.5f;
    [SerializeField] private float _maxCameraHeight = 2000f;
    [SerializeField] private float _zoomStep = 0.1f;
    [SerializeField] private bool _useJoystic = false;
    [SerializeField] private Joystick _joystick;

    private Transform _transform;
    private CameraRange _spaceCameraRange;

    private float _horizontal = 0;
    private float _vertical = 0;
    private float _scroll = 0;
    private Vector3 _offset = new Vector3(0, 0, 0);
    private Vector3 _zero = Vector3.zero;

    private float _speedMultiplier;
    private float _scaleMultiplier;

    private Vector3 _heightLimiter;
    private bool _ignoreScroll = false;
    private bool _ignoreAxis = false;

    private void Awake()
    {
        _transform = transform;
        _spaceCameraRange = GetComponent<CameraRange>();
        _heightLimiter = new Vector3(0, _minCameraHeight, 0);

        if (_useJoystic)
        {
            if (_joystick == null)
            {
                throw new ArgumentNullException("Поле Joystick не установлено!");
            }
            _joystick = _joystick.GetComponent<Joystick>();
        }
    }

    private void Start()
    {
        _transform = transform;
        _speedMultiplier = CalculateSpeedMultiplier();
        _scaleMultiplier = CalculateScaleMultiplier();
    }

    private void Update()
    {
        Move();
        _ignoreScroll = false;
        _ignoreAxis = false;
    }

    private void Move()
    {
        GetMovement();
        SetScroll();

        if (_forwardOnZ)
        {
            _offset.Set(_horizontal, _scroll, _vertical);
        }
        else
        {
            _offset.Set(_horizontal, _vertical, _scroll);
        }

        if(_offset != _zero)
        {
            //Debug.Log("FFF!");
            //Debug.Log(_offset);
            _transform.position += _offset;
            SetHeightLimit();

            Moved.Invoke();
            CalculateSpeedMultiplier();
            CalculateScaleMultiplier();
        }
    }

    private void GetMovement()
    {
        if (_useJoystic)
        {
            _horizontal = _joystick.Horizontal * _speedMultiplier;
            _vertical = _joystick.Vertical * _speedMultiplier;
        }
        else
        {
            _horizontal = Input.GetAxis("Horizontal") * _speedMultiplier;
            _vertical = Input.GetAxis("Vertical") * _speedMultiplier;
        }
    }

    private void SetScroll()
    {
        if (_ignoreScroll) return;
        _scroll = -Input.GetAxis("Mouse ScrollWheel") * _scaleMultiplier;
    }

    private float CalculateSpeedMultiplier()
    {
        return _speedMultiplier = _speed * Mathf.Sqrt(_spaceCameraRange.GetDistanceToSun()) / 5;
    }

    private float CalculateScaleMultiplier()
    {
        return _scaleMultiplier = _scrollSpeed * _spaceCameraRange.GetDistanceToSun();
    }

    private void SetHeightLimit()
    {
        float _tempLimit = _transform.position.y;

        if (_tempLimit < _minCameraHeight)
        {
            _tempLimit = _minCameraHeight;
        }
        else if (_tempLimit > _maxCameraHeight)
        {
            _tempLimit = _maxCameraHeight;
        }


        _heightLimiter.Set(_transform.position.x, _tempLimit, _transform.position.z);
        _transform.position = _heightLimiter;
    }


    //ToDo: ПЕРЕПИШИ ЭТО ДЕРЬМО::::::
    public void ZoomIn()
    {
        _ignoreScroll = true;
        _scroll = -_zoomStep * _scaleMultiplier;
    }
    public void ZoomOut()
    {
        _ignoreScroll = true;
        _scroll = _zoomStep * _scaleMultiplier;
    }

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
