using UnityEngine;
using System.Collections;
using PlanetsColony.Spaceships;
using PlanetsColony.Cargos.CargoHandlingByShip;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Factories;
using System;

namespace PlanetsColony.Pirates
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Pirate : MonoBehaviour, IFlying, IPirate
    {
        [SerializeField] private bool _isKeepCargos = true;
        private Rigidbody2D _rigidbody = null;
        private Transform _target = null;
        private Vector2 _spawnPosition = Vector2.zero;
        private IPirateCargoKeeper _pirateCargoKeeper = null;
        private bool _escape = false;

        private void Awake()
        {
            InitFields();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var factory = collision.gameObject.GetComponent<IFactory>();
            if (factory != null)
            {
                _rigidbody.velocity = Vector2.zero;
                factory.IsRobbed = true;
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

        public bool IsEscape()
        {
            return _escape;
        }

        public bool IsCanMove()
        {
            throw new NotImplementedException();
        }

        public void SetCanMove(bool value)
        {
            throw new NotImplementedException();
        }

        public void StealCargo(ICargo cargo)
        {
            if (_isKeepCargos)
            {
                _pirateCargoKeeper.Accept(cargo);
            }
        }

        public void TryStealCargo(ICargo cargo)
        {
            if (_isKeepCargos)
            {
                _pirateCargoKeeper.TryAccept(cargo);
            }
        }

        public void StealCargos(List<ICargo> cargos)
        {
            if (_isKeepCargos)
            {
                _pirateCargoKeeper.Accept(cargos);
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public Transform GetTarget()
        {
            return _target;
        }

        public Vector3 GetSpawnPosition()
        {
            return _spawnPosition;
        }

        private void InitFields()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            if (_isKeepCargos)
            {
                try
                {
                    _pirateCargoKeeper = GetComponent<IPirateCargoKeeper>();
                }
                catch
                {
                    throw new NullReferenceException("No component that implements the IPirateCargoKeeper interface was found.");
                }
            }
        }
    }
}