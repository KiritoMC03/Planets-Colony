using UnityEngine;

namespace PlanetsColony
{
    public class CargoGenerator : MonoBehaviour
    {
        public Cargo GenerateCargo(Resource.Type type, float min, float max)
        {
            return new Cargo(type, min, max);
        }
    }
}