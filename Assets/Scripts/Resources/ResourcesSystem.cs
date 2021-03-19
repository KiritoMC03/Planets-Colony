using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class ResourcesSystem : MonoBehaviour
    {
        [Serializable]
        public struct ResourceInfo
        {
            [SerializeField] private Resource.Type Type;
            [SerializeField] private string name;

            public string GetName()
            {
                return name;
            }

            public Resource.Type GetResourceType()
            {
                return Type;
            }
        }
        [SerializeField] private ResourcePanel _resourcePanel = null;
        [SerializeField] private TradingMenu _tradingMenu = null;
        [Header("Only unique types!")]
        [SerializeField] private List<ResourceInfo> _resourceInfo = null;

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
    }
}