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
        }

        public void UpdateResourcePanel()
        {
            _resourcePanel.RefreshElements(_resourceInfo);
        }
    }
}