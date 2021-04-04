using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;
using System.Numerics;

namespace PlanetsColony.Trading
{
    public class ResourceSalesAccount : MonoBehaviour
    {
        private static Dictionary<Resource.Type, BigInteger> _values = new Dictionary<Resource.Type, BigInteger>();
        private static BigInteger _allResourceSoldValue = 0;

        private void Awake()
        {
            _values = Resource.GenerateDictionaryByTypes<BigInteger>(0);
        }

        private void Start()
        {
            _allResourceSoldValue = SaveLoadSystem.Instance.LoadAllResourceSoldValue();
        }

        public static void AddSoldValue(Resource.Type type, BigInteger value)
        {
            _values[type] += value;
        }

        public static BigInteger GetSoldValue(Resource.Type type)
        {
            return _values[type];
        }

        public static void AddAllResourceSoldValue(BigInteger value)
        {
            Debug.Log("_allResourceSoldValue PRE: " + _allResourceSoldValue);
            Debug.Log("_allResourceSoldValue POST: " + _allResourceSoldValue + value);
            _allResourceSoldValue += value;
        }

        public static BigInteger GetAllResourceSoldValue()
        {
            return _allResourceSoldValue;
        }

        public ref Dictionary<Resource.Type, BigInteger> GetValuesList()
        {
            return ref _values;
        }
    }
}