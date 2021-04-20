using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;
using System;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Cargos
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ResourcesStorage))]
    public class CargoReceiver : MonoBehaviour
    {
        private ResourcesStorage _resourcesStorage = null;
        private Collider2D _collider = null;
        private Rigidbody2D _rigidbody = null;
        // временные переменные здесь:
        private SpaceshipCargoHandler _tempCargoHandler = null;

        private void Awake()
        {
            _resourcesStorage = GetComponent<ResourcesStorage>();
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            CheckInitializeFields();
            _collider.isTrigger = true;
        }

        private void CheckInitializeFields()
        {
            if (_resourcesStorage == null)
            {
                throw new Exception("Resources Storage component not found.");
            }
            if (_resourcesStorage == null)
            {
                throw new Exception("Collider component not found.");
            }
            if (_rigidbody == null)
            {
                throw new Exception("Rigidbody2D component not found.");
            }
        }

        public void AcceptCargo(List<Cargo> cargo)
        {
            _resourcesStorage.AcceptCargoFromShip(cargo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _tempCargoHandler = collision.GetComponent<SpaceshipCargoHandler>();
            if (_tempCargoHandler != null && _tempCargoHandler.CheckCargo())
            {
                _tempCargoHandler.DeliverCargo(this);
                ObjectPooler.Instance.DestroyObject(_tempCargoHandler.gameObject);
                StatsSystem.Instance.ReduceActiveShipsCount();
                return;
            }

            _tempCargoHandler = null;
        }
    }
}