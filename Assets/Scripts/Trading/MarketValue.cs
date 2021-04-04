using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;

namespace PlanetsColony.Trading
{
    public class MarketValue : MonoBehaviour
    {
        [SerializeField] private ResourceSalesAccount _resourceSalesAccount = null;
        [SerializeField] public byte BaseMarketValue => _baseMarketValue;
        private static byte _baseMarketValue = 10;
        private static Dictionary<Resource.Type, byte> _values = new Dictionary<Resource.Type, byte>();

        private void Awake()
        {
            if (_resourceSalesAccount == null)
            {
                throw new Exception("Resource Sales Accounte field must not be null.");
            }

            _values = Resource.GenerateDictionaryByTypes<byte>(0);
        }

        private void Start()
        {
            CalculateMarketValue();
        }

        public void CalculateMarketValue()
        {
            for (int i = 0; i < Resource.GetTypesCount(); i++)
            {
                var shareOfSale = ResourceSalesAccount.GetAllResourceSoldValue() / Mathf.Clamp(ResourceSalesAccount.GetSoldValue(Resource.GetType(i)), 1, ulong.MaxValue);
                var marketValue = Mathf.Clamp(shareOfSale, 1, byte.MaxValue - _baseMarketValue);
                _values[Resource.GetType(i)] = Convert.ToByte(marketValue + _baseMarketValue);
            }

            foreach (var item in _values)
            {
                
            }
        }

        public static byte GetBaseMarketValue()
        {
            return _baseMarketValue;
        }

        public static byte Get(Resource.Type type)
        {
            return _values[type];
        }
    }
}