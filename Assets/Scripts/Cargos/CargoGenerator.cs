using System;
using UnityEngine;
using PlanetsColony.Resources;
using System.Numerics;
using PlanetsColony.Levels;

namespace PlanetsColony.Cargos
{
    [RequireComponent(typeof(ICargoLoader))]
    public class CargoGenerator : MonoBehaviour
    {
        private ICargoLoader _cargoLoader = null;
        private BigInteger _tempValue = 0;
        private BigInteger _tempBigInt = 0;
        private int _tempInt = 0;

        private void Awake()
        {
            _cargoLoader = GetComponent<ICargoLoader>();
        }

        public Cargo GenerateCargo(Resource.Type type, BigInteger value)
        {
            _tempValue = CalculateFinalyValue(type, value);
            return new Cargo(type, _tempValue);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max)
        {
            _tempValue = CalculateFinalyValue(type, (ulong)UnityEngine.Random.Range(min, max));
            return new Cargo(type, _tempValue);
        }

        public Cargo GenerateCargo(Resource.Type type, ulong min, ulong max, BigInteger multiplier)
        {
            _tempValue = BigInteger.Multiply(multiplier, CalculateFinalyValue(type, (ulong)UnityEngine.Random.Range(min, max)));
            return new Cargo(type, _tempValue);
        }

        private BigInteger CalculateFinalyValue(Resource.Type type, BigInteger value)
        {
            _tempBigInt = BigInteger.Pow(value, SpaceshipsLevelling.Instance.GetCurrentLevel());
            _tempInt = Convert.ToInt32(_cargoLoader.GetResourceRare(type) * 100);
            _tempBigInt = (_tempBigInt * _tempInt) / 100;
            return _tempBigInt;
        }

        private BigInteger CalculateFinalyValue(Resource.Type type, ulong value)
        {
            _tempBigInt = BigInteger.Pow(value, SpaceshipsLevelling.Instance.GetCurrentLevel());
            _tempInt = Convert.ToInt32(_cargoLoader.GetResourceRare(type) * 100);
            _tempBigInt = (_tempBigInt * _tempInt) / 100;
            return _tempBigInt;
        }
    }
}