using UnityEngine;
using PlanetsColony.Resources;

namespace PlanetsColony
{
    public class CargoGenerator : MonoBehaviour
    {
        public Cargo GenerateCargo(Resource.Type type, uint min, uint max)
        {
            return new Cargo(type, min, max);
        }
    }
}