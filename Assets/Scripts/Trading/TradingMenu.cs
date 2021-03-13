using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class TradingMenu : MonoBehaviour
    {
        [SerializeField] private ResourceTradingElement _resourceTradingPrefab = null;
        [SerializeField] private ResourcesStorage _resourcesStorage = null;

        private ResourceTradingElement[] _generatedElements;

        private void Awake()
        {
            if (_resourcesStorage == null)
            {
                throw new ArgumentNullException("Заполните поле Resources Storage.");
            }
        }

        public void GenerateTradingList(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            _generatedElements = new ResourceTradingElement[resourceInfo.Count];

            for (int i = 0; i < resourceInfo.Count; i++)
            {
                var newElement = Instantiate(_resourceTradingPrefab, transform);
                var tempText = resourceInfo[i].GetName() + " " + _resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType());
                newElement.SetResourceName(tempText);
                _generatedElements[i] = newElement;
            }
        }

        public void RefreshElements(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                var tempText = resourceInfo[i].GetName() + " " + _resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType()); ;
                _generatedElements[i].SetResourceName(tempText);
            }
        }
    }
}