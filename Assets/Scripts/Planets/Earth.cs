using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlanetsColony
{
    public class Earth : Planet, ICargoReceiver
    {
        public void AcceptCargo(ICargo cargo)
        {
            Debug.Log("Get Cargo!");
        }
    }
}