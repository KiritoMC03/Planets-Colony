using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public abstract class Planet : MonoBehaviour, IAcceptShips
    {
        [SerializeField] private float sendShipWithCargoDelay = 3f;

        private Transform _transform = null;
        private Queue<IAcceptCargo> spaceShips = null;

        private void Awake()
        {
            _transform = transform;
            spaceShips = new Queue<IAcceptCargo>();
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

        public void AcceptShip(IAcceptCargo ship)
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

        private void SendCargo(IAcceptCargo ship)
        {
            ship.AcceptCargo(GenerateCargo());
        }

        private Cargo GenerateCargo()
        {
            return new Cargo(1f, 10f);
        }
    }
}