using UnityEngine;
using PlanetsColony.Resources;
using System.Numerics;

namespace PlanetsColony
{
    public class CargoGenerator : MonoBehaviour
    {
        public Cargo GenerateCargo(Resource.Type type, BigInteger value)
        {
            return new Cargo(type, value);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max)
        {
            return new Cargo(type, min, max);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max, BigInteger multiplier)
        {
            return new Cargo(type, min, max, multiplier);
        }
    }
}