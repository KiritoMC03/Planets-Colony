using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;

namespace PlanetsColony.Trading
{
    public class ResourceSalesAccount : MonoBehaviour
    {
        private static Dictionary<Resource.Type, ulong> _values = new Dictionary<Resource.Type, ulong>();
        private static ulong _allResourceSoldValue = 0;

        private void Awake()
        {
            _values = Resource.GenerateDictionaryByTypes<ulong>(0);
        }

        public static void AddSoldValue(Resource.Type type, ulong value)
        {
            _values[type] += value;
        }

        public static ulong GetSoldValue(Resource.Type type)
        {
            return _values[type];
        }

        public static ulong AddAllResourceSoldValue(ulong value)
        {
            return _allResourceSoldValue += value;
        }

        public static ulong GetAllResourceSoldValue()
        {
            return _allResourceSoldValue;
        }

        public ref Dictionary<Resource.Type, ulong> GetValuesList()
        {
            return ref _values;
        }
    }
}