using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PlanetsColony.Resources
{
    public class ResourceRarity : MonoBehaviour
    {
        [Serializable]
        public struct ResourceRareInfo
        {
            [SerializeField] private Resource.Type Type;
            [Header("Precent (0-100)")]
            [SerializeField] private int _rare;

            public int GetRare()
            {
                return _rare;
            }

            public Resource.Type GetResourceType()
            {
                return Type;
            }
        }


        private void Awake()
        {
            /*
            if (_resourceSalesAccount == null)
            {
                throw new Exception("Resource Sales Accounte field must not be null.");
            }
            */
        }
    }
}