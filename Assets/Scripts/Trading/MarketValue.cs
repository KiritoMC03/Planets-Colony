using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlanetsColony.Resources;
using System.Numerics;

namespace PlanetsColony.Trading
{
    public class MarketValue : MonoBehaviour
    {
        [SerializeField] private ResourceSalesAccount _resourceSalesAccount = null;
        [SerializeField] public byte BaseMarketValue => BASE_MARKET_VALUE;
        private const byte BASE_MARKET_VALUE = 10;
        private static Dictionary<Resource.Type, byte> _values = new Dictionary<Resource.Type, byte>();
        // temp variables:
        private BigInteger _shareOfSale = 1;
        private float _tempMarketValue = 1f;

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

        private void CalculateMarketValue()
        {
            for (int i = 0; i < Resource.GetPossibleTypesCount(); i++)
            {
                try
                {
                    _shareOfSale = ResourceSalesAccount.GetAllResourceSoldValue() / ResourceSalesAccount.GetSoldValue(Resource.GetType(i));
                }
                catch
                {
                    _shareOfSale = ResourceSalesAccount.GetAllResourceSoldValue() / (ResourceSalesAccount.GetSoldValue(Resource.GetType(i)) + 1);
                }

                _tempMarketValue = Mathf.Clamp((float)_shareOfSale, 1, byte.MaxValue - BASE_MARKET_VALUE);
                _values[Resource.GetType(i)] = Convert.ToByte(_tempMarketValue + BASE_MARKET_VALUE);
            }
        }

        public static byte GetBaseMarketValue()
        {
            return BASE_MARKET_VALUE;
        }

        public static byte Get(Resource.Type type)
        {
            return _values[type];
        }
    }
}