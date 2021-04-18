using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace Assets.Scripts.WorkWithSpaceships
{
    public class SpaceshipsStoragePort : MonoBehaviour, ISpaceshipsStoragePort
    {
        private Queue<SpaceshipCargoHandler> aceptedSpaceShips = null;

        private void Awake()
        {
            aceptedSpaceShips = new Queue<SpaceshipCargoHandler>();
        }

        public void AddShip(SpaceshipCargoHandler ship)
        {
            aceptedSpaceShips.Enqueue(ship);
        }

        public void TryAddShip(SpaceshipCargoHandler ship)
        {
            if (ship != null)
            {
                aceptedSpaceShips.Enqueue(ship);
            }
        }

        public Queue<SpaceshipCargoHandler> GetAcceptedShips()
        {
            return aceptedSpaceShips;
        }
    }
}