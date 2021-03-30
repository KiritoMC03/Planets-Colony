using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ResourcePanel : Menu
    {
        [SerializeField] private Text _resourceCountPrefab = null;
        [SerializeField] private ResourcesStorage _resourcesStorage = null;

        private Text[] _generatedElements;
        private Text _tempNewElement = null;

        private void Awake()
        {
            if(_resourcesStorage == null)
            {
                throw new ArgumentNullException("Заполните поле Resources Storage.");
            }
        }

        public void GenerateResourceList(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            _generatedElements = new Text[resourceInfo.Count];

            for (int i = 0; i < resourceInfo.Count; i++)
            {
                _tempNewElement = CreateResourceElement();
                _tempNewElement.text = CreateResourceCountText(resourceInfo[i]);
                _generatedElements[i] = _tempNewElement;
            }

            _tempNewElement = null;
        }

        private Text CreateResourceElement()
        {
             return Instantiate(_resourceCountPrefab, transform);
        }

        public void RefreshElements(List<ResourcesSystem.ResourceInfo> resourceInfo)
        { 
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                _generatedElements[i].text = CreateResourceCountText(resourceInfo[i]);;
            }
        }

        private string CreateResourceCountText(ResourcesSystem.ResourceInfo resourceInfo)
        {
            var resourceValue = Converter.ValueToString(_resourcesStorage.GetResourceValue(resourceInfo.GetResourceType()));
            return resourceInfo.GetName() + resourceValue + ResourcesSystem.GetUnitsOfMeasurement();
        }
    }
}