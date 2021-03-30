using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class TradingSystem : MonoBehaviour
    {
        [SerializeField] internal static TradingSystem Instance = null;

        [SerializeField] private ResourcesStorage _resourcesStorage = null;
        [SerializeField] private byte _baseMarketValue = 10;
        private Resource[] _resources = null;

        private void Awake()
        {
            Instance = this;
            if (_resourcesStorage == null)
            {
                throw new Exception("Необходимо установить поле ResourcesStorage.");
            }
        }

        private void Start()
        {
            CalculateMarketValue();
        }

        public void CalculateMarketValue()
        {
            if (_resourcesStorage != null)
            {
                _resources = _resourcesStorage.GetInitResourcesRef();
                for (int i = 0; i < _resources.Length; i++)
                {
                    var mult = Mathf.Clamp(StatsSystem.Instance.GetAllResourceSoldValue() / Mathf.Clamp(_resources[i].GetSoldValue(), 1, ulong.MaxValue), 1, 245);
                    byte mVal = Convert.ToByte(Convert.ToByte(mult) + _baseMarketValue);

                    _resources[i].SetMarketValue(mVal);
                }
            }
        }

        private uint GetBaseMarketValue()
        {
            return _baseMarketValue;
        }
    }
}