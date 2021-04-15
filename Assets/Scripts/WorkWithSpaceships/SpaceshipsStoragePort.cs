using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Cargos;

namespace Assets.Scripts.WorkWithSpaceships
{
    public class SpaceshipsStoragePort : MonoBehaviour, ISpaceshipsStoragePort
    {
        private Queue<CargoHandler> aceptedSpaceShips = null;

        private void Awake()
        {
            aceptedSpaceShips = new Queue<CargoHandler>();
        }

        public void AddShip(CargoHandler ship)
        {
            aceptedSpaceShips.Enqueue(ship);
        }

        public void TryAddShip(CargoHandler ship)
        {
            if (ship != null)
            {
                aceptedSpaceShips.Enqueue(ship);
            }
        }

        public Queue<CargoHandler> GetAcceptedShips()
        {
            return aceptedSpaceShips;
        }
    }
}