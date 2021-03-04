using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
	public class CameraRotateAround : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private float _sensitivity = 3;
		[SerializeField] private Vector3 _startOffset = new Vector3(0, 0, 5);
		[Range(0, 90)]
		[SerializeField] private float _verticalRotationLimit = 80;
		[SerializeField] private float _zoom = 0.25f;
		[SerializeField] private float _zoomMax = 10;
		[SerializeField] private float _zoomMin = 3;


		private Transform _transform;
		private Vector3 _offset;
		private float x, y;
		private bool _mousePress = false;

		void Start()
		{
			_transform = transform;
			SetStartPosition();
		}

		void Update()
		{

			CheckScroll();
			CheckMousePress();

			if (_mousePress)
			{
				CalculatePosition();
				SetRotation();
				SetPosition();
			}
		}

		private void SetStartPosition()
		{
			_offset = new Vector3(_startOffset.x, _startOffset.y, -Mathf.Abs(_zoomMax + _zoomMin) / 2 - _startOffset.z);
			_transform.position = _target.position + _offset;
		}

		private void CheckScroll()
		{
			_offset.z += _zoom * Input.GetAxis("Mouse ScrollWheel") * 10;
			SetPosition();
		}

		private void CheckMousePress()
		{
			if (Input.GetMouseButtonDown(0))
			{
				_mousePress = true;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				_mousePress = false;
			}
		}

		private void CalculatePosition()
		{
			_offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(_zoomMax), -Mathf.Abs(_zoomMin));
			x = _transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivity;
			y += Input.GetAxis("Mouse Y") * _sensitivity;
			y = Mathf.Clamp(y, -_verticalRotationLimit, _verticalRotationLimit);
		}

		private void SetPosition()
		{
			_offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(_zoomMax), -Mathf.Abs(_zoomMin));
			_transform.position = _transform.localRotation * _offset + _target.position;
		}

		private void SetRotation()
		{
			_transform.localEulerAngles = new Vector3(-y, x, 0);
		}
	}
}