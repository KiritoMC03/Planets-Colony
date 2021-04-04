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
        private Dictionary<Resource.Type, byte> _values = new Dictionary<Resource.Type, byte>();

        private void Awake()
        {
            if (_resourceSalesAccount == null)
            {
                throw new Exception("Resource Sales Accounte field must not be null.");
            }
        }

        private void Start()
        {
            CalculateMarketValue();
        }

        public void CalculateMarketValue()
        {
            foreach (var item in _values)
            {
                var shareOfSale = ResourceSalesAccount.GetAllResourceSoldValue() / Mathf.Clamp(ResourceSalesAccount.GetSoldValue(item.Key), 1, ulong.MaxValue);
                var marketValue = Mathf.Clamp(shareOfSale, 1, byte.MaxValue - _baseMarketValue);
                _values[item.Key] = Convert.ToByte(marketValue + _baseMarketValue);
            }
        }

        public static byte GetBaseMarketValue()
        {
            return _baseMarketValue;
        }
    }
}