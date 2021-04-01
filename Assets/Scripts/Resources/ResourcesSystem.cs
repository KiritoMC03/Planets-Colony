using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class ResourcesSystem : MonoBehaviour
    {
        [SerializeField] internal static ResourcesSystem Instance = null;

        [Serializable]
        public struct ResourceInfo
        {
            [SerializeField] private Resource.Type Type;
            [SerializeField] private string name;
            [Header("За тонну.")]
            [SerializeField] private ulong minCost;
            [SerializeField] private ulong maxCost;

            public string GetName()
            {
                return name;
            }

            public Resource.Type GetResourceType()
            {
                return Type;
            }

            public ulong GetMinCost()
            {
                return minCost;
            }

            public ulong GetMaxCost()
            {
                return maxCost;
            }
        }

        [SerializeField] private ResourcePanel _resourcePanel = null;
        [SerializeField] private TradingMenu _tradingMenu = null;
        [Header("Не должны повторяться!")]
        [SerializeField] private List<ResourceInfo> _resourceInfo = null;

        private static string unitsOfMeasurement = " тонн.";

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if (!_resourcePanel.gameObject.activeInHierarchy)
            {
                _resourcePanel.gameObject.SetActive(true);
                _resourcePanel.GenerateResourceList(_resourceInfo);
                _resourcePanel.gameObject.SetActive(false);
            }
            else
            {
                _resourcePanel.GenerateResourceList(_resourceInfo);
            }



            if (!_tradingMenu.gameObject.activeInHierarchy)
            {
                _tradingMenu.gameObject.SetActive(true);
                _tradingMenu.GenerateTradingList(_resourceInfo);
                _tradingMenu.gameObject.SetActive(false);
            }
            else
            {
                _tradingMenu.GenerateTradingList(_resourceInfo);
            }
        }

        public void UpdateResources()
        {
            _resourcePanel.RefreshElements(_resourceInfo);
            _tradingMenu.RefreshElements(_resourceInfo);
        }

        public static string GetUnitsOfMeasurement()
        {
            return unitsOfMeasurement;
        }

        public ulong GetMinCost(Resource.Type type)
        {
            for (int i = 0; i < _resourceInfo.Count; i++)
            {
                if(_resourceInfo[i].GetResourceType() == type)
                {
                    return _resourceInfo[i].GetMinCost();
                }
            }

            throw new Exception("Ошибка. Не найден тип ресурса, либо стоимость.");
        }

        public ulong GetMaxCost(Resource.Type type)
        {
            for (int i = 0; i < _resourceInfo.Count; i++)
            {
                if (_resourceInfo[i].GetResourceType() == type)
                {
                    return _resourceInfo[i].GetMaxCost();
                }
            }

            throw new Exception("Ошибка. Не найден тип ресурса, либо стоимость.");
        }
    }
}