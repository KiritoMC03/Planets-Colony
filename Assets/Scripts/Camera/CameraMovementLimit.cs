using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(CameraMovement))]
    public class CameraMovementLimit : MonoBehaviour
    {
        [SerializeField] private Vector2 maximum = Vector2.zero;
        [SerializeField] private Vector2 minimum = Vector2.zero;

        private Transform _transform;
        private CameraMovement _cameraMovement;
        private Vector3 _tempPosition = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _cameraMovement = GetComponent<CameraMovement>();
            _cameraMovement.Moved.AddListener(Check);
        }

        public void Check()
        {
            Debug.Log("Check!");
            if (_cameraMovement == null)
            {
                throw new Exception("Отсутствует компонент CameraMovement.");
            }

            _tempPosition.x = ClampAxis(_transform.position.x, minimum.x, maximum.x);
            _tempPosition.y = ClampAxis(_transform.position.y, minimum.y, maximum.y);
            _tempPosition.z = _transform.position.z;

            _transform.position = _tempPosition;
        }

        private float ClampAxis(float position, float minimum, float maximum)
        {
            if (position > maximum || position < minimum)
            {
                return Mathf.Clamp(position, minimum, maximum);
            }
            return position;
        }
    }
}