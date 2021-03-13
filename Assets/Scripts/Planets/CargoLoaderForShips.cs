using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PlanetsColony
{
    [RequireComponent(typeof(Factory))]
    public class CargoLoaderForShips : MonoBehaviour
    {
        [SerializeField] private Resource.Type _resourceType;
        [SerializeField] private float sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private Factory _factory = null;
        private Queue<CargoHandler> aceptedSpaceShips = null;

        private void Awake()
        {
            _transform = transform;
            _factory = GetComponent<Factory>();
            aceptedSpaceShips = new Queue<CargoHandler>();
        }

        private void Start()
        {
            StartCoroutine(SendShipWithCargoRoutine());
        }

        private IEnumerator SendShipWithCargoRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(sendShipWithCargoDelay);
                SendShipWithCargo();
            }
        }

        public void AcceptShip(CargoHandler ship)
        {
            aceptedSpaceShips.Enqueue(ship);
            ship.AcceptNow();
        }

        public void SendShipWithCargo()
        {
            if (aceptedSpaceShips.Count < 1)
            {
                return;
            }
            var ship = aceptedSpaceShips.Dequeue();
            _factory.SendCargo(ship, _resourceType);
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }

        
    }
}