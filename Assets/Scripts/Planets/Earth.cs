using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlanetsColony
{
    public class Earth : MonoBehaviour, ICargoReceiver
    {
        private ResourcesStorage _resourcesStorage = null;

        private void Awake()
        {
            _resourcesStorage = GetComponent<ResourcesStorage>();
        }

        public void AcceptCargo(ICargo cargo)
        {
            _resourcesStorage.AcceptCargoFromShip(cargo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var cargoTransporter = collision.GetComponent<ICargoTransporter>();
            var cargoHandler = collision.GetComponent<ITransferringCargo>();

            if (cargoTransporter != null && cargoHandler.CheckCargo())
            {
                cargoHandler.DeliverCargo(this);
                ObjectPooler.Instance.DestroyObject(collision.gameObject);
                return;
            }
        }
    }
}