using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlanetsColony.Resources;
using PlanetsColony.Trading;
using System.Numerics;

namespace PlanetsColony
{
    public class TradingMenu : Menu
    {
        [SerializeField] private ResourceTradingElement _resourceTradingPrefab = null;
        [SerializeField] private ResourcesStorage _resourcesStorage = null;
        [SerializeField] private Transform _elementsContainer = null;
        [SerializeField] private Text _elementsCountIsNull = null;

        private ResourceTradingElement[] _generatedElements;
        private uint _activeElementsCount = 0;
        private static string _elementsCountIsNullMessage = "На складе пока нет ресурсов!";

        private void Awake()
        {
            if (_resourcesStorage == null)
            {
                throw new ArgumentNullException("Заполните поле Resources Storage.");
            }
            if (_elementsContainer == null)
            {
                throw new ArgumentNullException("Заполните поле Elements Container.");
            }
            if (_elementsCountIsNull == null)
            {
                throw new ArgumentNullException("Заполните поле Elements Count Is Null.");
            }
        }

        #region ResourceListWork
        public override void GenerateList(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            _generatedElements = new ResourceTradingElement[resourceInfo.Count];

            for (int i = 0; i < resourceInfo.Count; i++)
            {
                if (_elementsContainer == null)
                {
                    throw new ArgumentNullException("Заполните поле Elements Container.");
                }

                var tempResourceValue = _resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType());

                var newElement = Instantiate(_resourceTradingPrefab, _elementsContainer);
                var tempText = resourceInfo[i].GetName();
                newElement.SetTradingMenu(this);
                newElement.SetResourceNameAndValue(tempText, tempResourceValue);
                newElement.SetResourceType(resourceInfo[i].GetResourceType());
                _generatedElements[i] = newElement;

                if (tempResourceValue == 0)
                {
                    newElement.gameObject.SetActive(false);
                }
                else
                {
                    newElement.gameObject.SetActive(true);
                    _activeElementsCount++;
                }
            }
            CheckActiveElementsCount();
        }

        public void RefreshElements(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            _activeElementsCount = 0;
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                var tempResourceValue = _resourcesStorage.GetResourceValue(_generatedElements[i].GetResourceType());
                if (tempResourceValue == 0)
                {
                    _generatedElements[i].gameObject.SetActive(false);
                }
                else
                {
                    _generatedElements[i].gameObject.SetActive(true);
                    _activeElementsCount++;

                    var tempText = resourceInfo[i].GetName();
                    _generatedElements[i].SetResourceNameAndValue(tempText, _resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType()));
                    _generatedElements[i].SetResourceType(resourceInfo[i].GetResourceType());
                }
            }
            CheckActiveElementsCount();
        }

        #endregion

        #region TradeWork
        public void SaleAllResourcesTypes()
        {
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                _generatedElements[i].SaleAll();
            }
        }
        #endregion

        #region GettersSetters
        public BigInteger GetResourceToTrade(Resource.Type type, BigInteger value)
        {
            return _resourcesStorage.GetResourceToTrade(type, value);
        }

        public ResourcesStorage GetResourcesStorageLink()
        {
            return _resourcesStorage;
        }
        #endregion

        #region Utils
        private void CheckActiveElementsCount()
        {
            if (_activeElementsCount == 0)
            {
                _elementsCountIsNull.text = _elementsCountIsNullMessage;
                _elementsCountIsNull.gameObject.SetActive(true);
            }
            else
            {
                _elementsCountIsNull.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}