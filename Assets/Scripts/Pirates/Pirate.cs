using UnityEngine;
using System.Collections;
using PlanetsColony.Spaceships;
using PlanetsColony.Cargos.CargoHandlingByShip;
using System.Collections.Generic;
using PlanetsColony.Cargos;

namespace PlanetsColony.Pirates
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Pirate : MonoBehaviour, IFlying, IPirate
    {
        [SerializeField] private float _speed = 100f;
        private Transform _target = null;
        private List<ICargo> _cargos = null;
        private bool _escape = false;
        private Vector2 _spawnPosition = Vector2.zero;
        private Transform _transform = null;
        private Rigidbody2D _rigidbody = null;
        private Vector3 _localVelocity = Vector3.zero;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_escape)
            {
                MoveTo(_spawnPosition);
            }
            else
            {
                if (_target != null)
                {
                    MoveTo(_target.position);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var cargoHandler = collision.gameObject.GetComponent<ISpaceshipCargoHandler>();
            if (cargoHandler != null)
            {
                cargoHandler.DeliverCargo(this);
                Escape();
            }
        }

        public void SetSpawnPosition(Vector2 position)
        {
            _spawnPosition = position;
        }

        public void Escape()
        {
            _escape = true;
        }

        public void MoveTo(Vector2 target)
        {
            SetLocalVelocity(CalculateVelocity(_speed, target));
        }

        private void SetLocalVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = Vector2.zero;

            _localVelocity = _transform.InverseTransformDirection(_rigidbody.velocity);
            _localVelocity = velocity;
            _rigidbody.velocity = _transform.TransformDirection(_localVelocity);
        }

        private Vector2 CalculateVelocity(float speed, Vector2 target)
        {
            var offset = (target - (Vector2)_transform.position).normalized;
            return speed * offset * Time.fixedDeltaTime;
        }

        public bool IsCanMove()
        {
            throw new System.NotImplementedException();
        }

        public void SetCanMove(bool value)
        {
            throw new System.NotImplementedException();
        }

        public void StealCargos(List<ICargo> cargos)
        {
            this._cargos = cargos;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public Transform GetTarget()
        {
            return _target;
        }
    }
}