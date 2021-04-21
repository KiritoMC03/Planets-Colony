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
    public class CargoReceiver : MonoBehaviour, ICargoReceiver
    {
        private IResourcesStorage _resourcesStorage = null;
        private Collider2D _collider = null;
        private Rigidbody2D _rigidbody = null;
        // временные переменные здесь:
        private ISpaceshipCargoHandler _tempCargoHandler = null;

        private void Awake()
        {
            InitFields();
            _collider.isTrigger = true;
        }

        private void InitFields()
        {
            _resourcesStorage = GetComponent<IResourcesStorage>();
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();

            if (_resourcesStorage == null)
            {
                throw new NullReferenceException("No component that implements the IResourcesStorage interface was found.");
            }
            if (_collider == null)
            {
                throw new Exception("Collider component not found.");
            }
            if (_rigidbody == null)
            {
                throw new Exception("Rigidbody2D component not found.");
            }
        }

        public void Receive(List<ICargo> cargo)
        {
            _resourcesStorage.AcceptCargoFromShip(cargo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _tempCargoHandler = collision.GetComponent<ISpaceshipCargoHandler>();
            if (_tempCargoHandler != null && _tempCargoHandler.CheckCargo())
            {
                _tempCargoHandler.DeliverCargo(this);
                ObjectPooler.Instance.DestroyObject(_tempCargoHandler.GetUnityObject());
                StatsSystem.Instance.ReduceActiveShipsCount();
                return;
            }

            _tempCargoHandler = null;
        }
    }
}