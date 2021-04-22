using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PlanetsColony.Resources
{
    public class ResourceRarity : MonoBehaviour, IResourceRarity
    {
        [Serializable]
        public struct ResourceInfo
        {
            [SerializeField] private Resource.Type Type;
            [Header("Precent (0-100)")]
            [SerializeField] private int _rare;

            public float GetRare()
            {
                return _rare / 100f;
            }

            public Resource.Type GetResourceType()
            {
                return Type;
            }
        }
        [SerializeField] private ResourceInfo[] _resourceInfo;

        private void Awake()
        {
            for (int i = 0; i < _resourceInfo.Length; i++)
            {
                if (_resourceInfo[i].GetRare() * 100 > 100 || _resourceInfo[i].GetRare() * 100 < 0)
                {
                    Application.Quit();
                    throw new Exception("Rare value Incorrect.");
                }
            }
        }

        public ResourceInfo[] GetResourceInfo()
        {
            return _resourceInfo;
        }

        public float GetResourceRare(Resource.Type type)
        {
            for (int i = 0; i < _resourceInfo.Length; i++)
            {
                if (_resourceInfo[i].GetResourceType() == type)
                {
                    return _resourceInfo[i].GetRare();
                }
            }
            return 0f;
        }
    }
}