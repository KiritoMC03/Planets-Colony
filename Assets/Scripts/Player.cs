using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;

        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;

        private float horizontal = 0f;
        private float vertical = 0f;
        private Quaternion rotate = Quaternion.identity;
        private float speedMultiplier = 0f;
        private Vector2 movement = Vector2.zero;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            GetMoveInput();
            _rigidbody.AddRelativeForce(CalculateMovement());
            _transform.rotation = CalculateRotation();
        }

        private Vector2 CalculateMovement()
        {
            movement.Set(0, vertical);
            return movement;
        }

        private Quaternion CalculateRotation()
        {
            rotate.Set(0, 0, horizontal, 0);
            return rotate;
        }

        private void GetMoveInput()
        {
            speedMultiplier = Time.fixedDeltaTime * speed;
            vertical = Input.GetAxis("Vertical") * speedMultiplier;
        }

        private void GetRotateInput()
        {
            horizontal = Input.GetAxis("Horizontal") * speedMultiplier;
        }
    }
}
