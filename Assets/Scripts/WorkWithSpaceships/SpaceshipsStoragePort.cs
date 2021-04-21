using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace Assets.Scripts.WorkWithSpaceships
{
    public class SpaceshipsStoragePort : MonoBehaviour, ISpaceshipsStoragePort
    {
        private Queue<ISpaceshipCargoHandler> aceptedSpaceShips = null;

        private void Awake()
        {
            aceptedSpaceShips = new Queue<ISpaceshipCargoHandler>();
        }

        public void AddShip(ISpaceshipCargoHandler ship)
        {
            aceptedSpaceShips.Enqueue(ship);
        }

        public void TryAddShip(ISpaceshipCargoHandler ship)
        {
            if (ship != null)
            {
                aceptedSpaceShips.Enqueue(ship);
            }
        }

        public Queue<ISpaceshipCargoHandler> GetAcceptedShips()
        {
            return aceptedSpaceShips;
        }
    }
}