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
                var newElement = Instantiate(_resourceCountPrefab, transform);
                newElement.text = resourceInfo[i].GetName() + " " + (float)_resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType());
                _generatedElements[i] = newElement;
            }
        }

        public void RefreshElements(List<ResourcesSystem.ResourceInfo> resourceInfo)
        { 
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                _generatedElements[i].text = resourceInfo[i].GetName() + " " + (float)_resourcesStorage.GetResourceValue(resourceInfo[i].GetResourceType());
            }
        }
    }
}