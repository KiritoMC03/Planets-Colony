using UnityEngine;
using PlanetsColony.Resources;
using System.Numerics;
using PlanetsColony.Levels;

namespace PlanetsColony
{
    public class CargoGenerator : MonoBehaviour
    {
        private BigInteger _tempValue = 0;

        public Cargo GenerateCargo(Resource.Type type, BigInteger value)
        {
            _tempValue = CalculateFinalyValue(value);
            return new Cargo(type, _tempValue);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max)
        {
            _tempValue = CalculateFinalyValue((ulong)Random.Range(min, max));
            return new Cargo(type, _tempValue);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max, BigInteger multiplier)
        {
            _tempValue = BigInteger.Multiply(multiplier, CalculateFinalyValue((ulong)Random.Range(min, max)));
            return new Cargo(type, _tempValue);
        }

        private BigInteger CalculateFinalyValue(BigInteger value)
        {
            return BigInteger.Pow(value, SpaceshipsLevelling.Instance.GetCurrentLevel());
        }

        private BigInteger CalculateFinalyValue(ulong value)
        {
            return BigInteger.Pow(value, SpaceshipsLevelling.Instance.GetCurrentLevel());
        }
    }
}