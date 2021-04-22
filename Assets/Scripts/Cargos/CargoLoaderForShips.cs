using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;
using System;
using PlanetsColony.Factories;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Cargos
{
    public class CargoLoaderForShips : MonoBehaviour, ICargoLoader
    {
        public void LoadCargoForShip(ISpaceshipCargoHandler ship, IFactory factory, ResourceRarity.ResourceInfo[] resourceInfo)
        {
            for (int i = 0; i < resourceInfo.Length; i++)
            {
                factory.SendCargo(ship, resourceInfo[i].GetResourceType());
            }
        }
    }
}