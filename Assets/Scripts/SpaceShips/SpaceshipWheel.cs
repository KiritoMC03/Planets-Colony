using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(Spaceship))]
    public class SpaceshipWheel : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1f;

        private Transform _transform = null;
        private Spaceship _spaceship = null;
        private Vector3 _tempDifference = Vector3.zero;
        private float _tempZRotation = 0f;

        private void Awake()
        {
            _transform = transform;
            _spaceship = GetComponent<Spaceship>();

            if (_spaceship == null)
            {
                throw new NullReferenceException("Spaceship component not found.");
            }
        }

        private void Update()
        {
            if (_spaceship.IsCanMove())
            {
                RotateTo(_spaceship.GetTarget().position);
            }
        }

        private void RotateTo(Vector3 target)
        {
            _tempDifference = target - _transform.position;
            _tempZRotation = Mathf.Atan2(_tempDifference.y, _tempDifference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(_tempZRotation - 90, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }
}