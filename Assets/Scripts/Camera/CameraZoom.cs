using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 1f;
        [SerializeField] private float _minCameraHeight = 0.5f;
        [SerializeField] private float _maxCameraHeight = 2000f;
        [SerializeField] private float _zoomStep = 0.1f;

        private Transform _transform = null;
        private CameraDistance _cameraDistance;
        private Vector3 _heightLimiter;
        private Vector3 _zeroOffset = Vector3.zero;
        private Vector3 _offset = Vector3.zero;
        private float _scroll = 0f;
        private float _zoomMultiplier = 1f;
        private bool _buttonUsed = false;

        private void Awake()
        {
            _transform = transform;
            _cameraDistance = GetComponent<CameraDistance>();
            _heightLimiter = new Vector3(0, _minCameraHeight, 0);
        }

        private void Update()
        {
            Zoom();
            _buttonUsed = false;
        }

        private void Zoom()
        {
            SetScroll();
            _offset.Set(0f, 0f, SetScroll() * _zoomMultiplier);

            if (_offset != _zeroOffset)
            {
                _transform.position += _offset;
                CalculateZoomMultiplier();
            }
        }

        private float SetScroll()
        {
            if (!_buttonUsed)
            {
                _scroll = Input.GetAxis("Mouse ScrollWheel");
            }
            return _scroll;
        }

        private float CalculateZoomMultiplier()
        {
            return _zoomMultiplier = _scrollSpeed * _cameraDistance.GetDistanceToSun();
        }

        public void ZoomIn()
        {
            _buttonUsed = true;
            _scroll = _zoomStep;
        }

        public void ZoomOut()
        {
            _buttonUsed = true;
            _scroll = -_zoomStep;
        }

    }
}