﻿using System;
using UnityEngine;
using PlanetsColony.Resources;
using System.Numerics;
using PlanetsColony.Levels;

namespace PlanetsColony.Cargos
{
    [RequireComponent(typeof(IResourceRarity))]
    public class CargoGenerator : MonoBehaviour, ICargoGenerator
    {
        private IResourceRarity _resourceRarity = null;
        private BigInteger _tempValue = 0;
        private BigInteger _tempBigInt = 0;
        private int _tempInt = 0;

        private void Awake()
        {
            _resourceRarity = GetComponent<IResourceRarity>();
            if (_resourceRarity == null)
            {
                throw new NullReferenceException("No component that implements the IResourceRarity interface was found.");
            }
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
            _tempBigInt = BigInteger.Pow(value, SpaceshipsLevelling.Instance.CurrentLevel);
            _tempInt = Convert.ToInt32(_resourceRarity.GetResourceRare(type) * 100);
            _tempBigInt = (_tempBigInt * _tempInt) / 100;
            return _tempBigInt;
        }

        private BigInteger CalculateFinalyValue(Resource.Type type, ulong value)
        {
            _tempBigInt = BigInteger.Pow(value, SpaceshipsLevelling.Instance.CurrentLevel);
            _tempInt = Convert.ToInt32(_resourceRarity.GetResourceRare(type) * 100);
            _tempBigInt = (_tempBigInt * _tempInt) / 100;
            return _tempBigInt;
        }
    }
}