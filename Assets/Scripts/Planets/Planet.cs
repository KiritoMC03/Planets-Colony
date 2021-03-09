using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public abstract class Planet : MonoBehaviour, IAcceptShips
    {
        [SerializeField] private Resource.Type _resourceType;
        [SerializeField] private float _minGeneratedResource = 0f;
        [SerializeField] private float _maxGeneratedResource = 100f;
        [SerializeField] private float sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private Queue<ITransferringCargo> spaceShips = null;

        private void Awake()
        {
            _transform = transform;
            spaceShips = new Queue<ITransferringCargo>();
        }

        private void Start()
        {
            StartCoroutine(SendShipWithCargoRoutine(sendShipWithCargoDelay));
        }

        private IEnumerator SendShipWithCargoRoutine(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                SendShipWithCargo();
            }
        }

        public void AcceptShip(ITransferringCargo ship)
        {
            spaceShips.Enqueue(ship);
            ship.AcceptNow();
        }

        public void SendShipWithCargo()
        {
            if(spaceShips.Count < 1)
            {
                return;
            }
            var ship = spaceShips.Dequeue();
            SendCargo(ship);
            ship.AcceptFinish();
            ship.SetUnityPosition(_transform.position);
        }

        private void SendCargo(ITransferringCargo ship)
        {
            ship.AcceptCargo(GenerateCargo());
        }

        private Cargo GenerateCargo()
        {
            return new Cargo(_resourceType, _minGeneratedResource, _maxGeneratedResource);
        }
    }
}