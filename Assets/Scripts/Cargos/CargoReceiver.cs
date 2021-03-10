using UnityEngine;
using System.Collections;

namespace PlanetsColony
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ResourcesStorage))]
    public class CargoReceiver : MonoBehaviour
    {
        private ResourcesStorage _resourcesStorage = null;
        private Collider2D _collider = null;

        private void Awake()
        {
            _resourcesStorage = GetComponent<ResourcesStorage>();
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        public void AcceptCargo(Cargo cargo)
        {
            _resourcesStorage.AcceptCargoFromShip(cargo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var cargoTransporter = collision.GetComponent<CargoHandler>();
            var cargoHandler = collision.GetComponent<CargoHandler>();

            if (cargoTransporter != null && cargoHandler.CheckCargo())
            {
                cargoHandler.DeliverCargo(this);
                ObjectPooler.Instance.DestroyObject(cargoTransporter.gameObject);
                StatsSystem.Instance.ReduceActiveShipsCount();
                return;
            }
        }
    }
}