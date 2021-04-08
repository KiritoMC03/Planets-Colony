using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlanetsColony.Resources;
using PlanetsColony.Utils;

namespace PlanetsColony
{
    public class ResourcePanel : Menu
    {
        [SerializeField] private Text _resourceCountPrefab = null;
        [SerializeField] private ResourcesStorage _resourcesStorage = null;
        [SerializeField] private Transform _container = null;

        private Text[] _generatedElements;
        private Text _tempNewElement = null;
        private List<ResourcesSystem.ResourceInfo> _tempResourceInfo = null;
        private string _resourceValue = null;

        private void Awake()
        {
            if(_resourcesStorage == null)
            {
                throw new ArgumentNullException("Resources Storage field must not be null.");
            }
        }

        public override void GenerateList(List<ResourcesSystem.ResourceInfo> resourceInfo)
        {
            _tempResourceInfo = resourceInfo;
            if (_container == null || _resourceCountPrefab == null || _resourcesStorage == null)
            {
                return;
            }

            _generatedElements = new Text[resourceInfo.Count];
            for (int i = 0; i < resourceInfo.Count; i++)
            {
                _tempNewElement = CreateResourceElement();
                if(_tempNewElement != null)
                {
                    _tempNewElement.text = CreateResourceCountText(resourceInfo[i]);
                    _generatedElements[i] = _tempNewElement;
                }
            }
            _tempNewElement = null;
        }

        private Text CreateResourceElement()
        {
            if (_container != null)
            {
                return Instantiate(_resourceCountPrefab, _container);
            }
            return null;
        }

        public void RefreshElements(List<ResourcesSystem.ResourceInfo> resourceInfo)
        { 
            if(_generatedElements.Length == 0)
            {
                GenerateList(_tempResourceInfo);
            }
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                _generatedElements[i].text = CreateResourceCountText(resourceInfo[i]);;
            }
        }

        private string CreateResourceCountText(ResourcesSystem.ResourceInfo resourceInfo)
        {
            _resourceValue = Converter.ValueToString(_resourcesStorage.GetResourceValue(resourceInfo.GetResourceType()));
            return resourceInfo.GetName() + _resourceValue + ResourcesSystem.GetUnitsOfMeasurement();
        }
    }
}