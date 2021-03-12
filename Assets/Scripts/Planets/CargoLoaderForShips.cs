using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoGenerator))]
    public class CargoLoaderForShips : MonoBehaviour
    {
        [SerializeField] private Resource.Type _resourceType;
        [SerializeField] private float _minGeneratedResource = 0f;
        [SerializeField] private float _maxGeneratedResource = 100f;
        [SerializeField] private float sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private CargoGenerator _cargoGenerator = null;
        private Queue<CargoHandler> aceptedSpaceShips = null;

        private void Awake()
        {
            _transform = transform;
            _cargoGenerator = GetComponent<CargoGenerator>();
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
            SendCargo(ship);
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }

        private void SendCargo(CargoHandler ship)
        {
            ship.AcceptCargo(_cargoGenerator.GenerateCargo(_resourceType, _minGeneratedResource, _maxGeneratedResource));
        }
    }
}