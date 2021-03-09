using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ResourcePanel : MonoBehaviour
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

        [SerializeField] private Text _resourceCountPrefab = null;
        [SerializeField] private ResourcesStorage _resourcesStorage = null;
        [Header("Only unique types!")]
        [SerializeField] private List<ResourceInfo> _resourceInfo = null;


        private Text[] _generatedElements = null;

        private void Awake()
        {
            if(_resourcesStorage == null)
            {
                throw new ArgumentNullException("Заполните поле Resources Storage.");
            }
        }

        private void Start()
        {
            GenerateResourceList();
        }

        private void GenerateResourceList()
        {
            _generatedElements = new Text[_resourceInfo.Count];

            for (int i = 0; i < _resourceInfo.Count; i++)
            {
                var newElement = Instantiate(_resourceCountPrefab, transform);
                newElement.text = _resourceInfo[i].GetName() + " " + _resourcesStorage.GetResourceValue(_resourceInfo[i].GetResourceType());
                _generatedElements[i] = newElement;
            }
        }

        public void RefreshElements()
        {
            for (int i = 0; i < _generatedElements.Length; i++)
            {
                _generatedElements[i].text = _resourceInfo[i].GetName() + " " + _resourcesStorage.GetResourceValue(_resourceInfo[i].GetResourceType());
            }
        }
    }
}