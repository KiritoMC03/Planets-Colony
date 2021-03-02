using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3 targetPosition = Vector3.zero;
        [SerializeField] private float speed = 1f;
        [SerializeField] private float rotationSpeed = 0.1f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;

        private float distanceDelta = 0f;
        private float tempZRotation = 0f;
        private Vector2 tempVelocity = Vector2.zero;
        private Vector3 tempDifference = Vector3.zero;
        private Vector3 tempLocalVelocity = Vector3.zero;
        private Vector3 tempTargetPosition = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
            distanceDelta = speed * Time.deltaTime;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (target != null)
            {
                tempTargetPosition = target.position;
            }
            else
            {
                if (targetPosition == Vector3.zero)
                {
                    Debug.LogError("TargetPosition установлено в (0, 0, 0)! Возможна ошибка.");
                }
                tempTargetPosition = targetPosition;
            }

            tempVelocity.Set(0, CalculateDistanceDelta());
            SetLocalVelocity(tempVelocity);
            RotateTo(tempTargetPosition);
        }

        private void RotateTo(Vector3 target)
        {
            tempDifference = target - _transform.position;
            tempZRotation = Mathf.Atan2(tempDifference.y, tempDifference.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(tempZRotation - 90, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }
        
        private float CalculateDistanceDelta()
        {
            return distanceDelta = speed * Time.deltaTime;
        }

        private void SetLocalVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = Vector2.zero;

            tempLocalVelocity = _transform.InverseTransformDirection(_rigidbody.velocity);
            tempLocalVelocity = velocity;
            _rigidbody.velocity = _transform.TransformDirection(tempLocalVelocity);
        }

        #region GettersSetters
        internal void SetTarget(Transform target)
        {
            this.target = target;
        }

        internal void SetTargetPosition(Vector3 target)
        {
            this.targetPosition = target;
        }
        #endregion


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<Planet>() != null)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Planet>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
