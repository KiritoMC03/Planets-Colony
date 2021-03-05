using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public abstract class Planet : MonoBehaviour, IAcceptShips
    {
        private Queue<IAcceptCargo> spaceShips = null;

        private void Awake()
        {
            spaceShips = new Queue<IAcceptCargo>();
        }

        private void Start()
        {
            StartCoroutine(SendShipWithCargoRoutine());
        }

        private IEnumerator SendShipWithCargoRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                SendShipWithCargo();
            }
        }

        public void AcceptShip(IAcceptCargo ship)
        {
            Debug.Log("AcceptShip");
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