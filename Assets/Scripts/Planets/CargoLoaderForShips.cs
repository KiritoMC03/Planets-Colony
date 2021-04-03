using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PlanetsColony
{
    [RequireComponent(typeof(Factory))]
    public class CargoLoaderForShips : MonoBehaviour
    {
        [SerializeField] private Resource.Type[] _resourceTypes;
        [SerializeField] private float _sendShipWithCargoDelay = 3f;

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
                yield return new WaitForSeconds(_sendShipWithCargoDelay);
                SendShipWithCargo();
            }
        }

        public Resource.Type[] GetResourceTypes()
        {
            return _resourceTypes;
        }

        public float GetSendShipWithCargoDelay()
        {
            return _sendShipWithCargoDelay;
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
            for (int i = 0; i < _resourceTypes.Length; i++)
            {
                _factory.SendCargo(ship, _resourceTypes[i]);
            }
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }
    }
}