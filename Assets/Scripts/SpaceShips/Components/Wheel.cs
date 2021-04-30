using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships.Components
{
    public class Wheel : MonoBehaviour, IWheel
    {
        [SerializeField] private float _rotationSpeed = 1f;

        private Vector3 _tempDifference = Vector3.zero;
        private float _tempZRotation = 0f;

        public void RotateTo(Transform rotatingObject, Vector3 target)
        {
            _tempDifference = target - rotatingObject.position;
            _tempZRotation = Mathf.Atan2(_tempDifference.y, _tempDifference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(_tempZRotation - 90, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }
}