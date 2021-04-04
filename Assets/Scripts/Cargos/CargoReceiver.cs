using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;

namespace PlanetsColony
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ResourcesStorage))]
    public class CargoReceiver : MonoBehaviour
    {
        private ResourcesStorage _resourcesStorage = null;
        private Collider2D _collider = null;

        // временные переменные здесь:
        private CargoHandler _tempCargoHandler = null;

        private void Awake()
        {
            _resourcesStorage = GetComponent<ResourcesStorage>();
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        public void AcceptCargo(List<Cargo> cargo)
        {
            _resourcesStorage.AcceptCargoFromShip(cargo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _tempCargoHandler = collision.GetComponent<CargoHandler>();
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