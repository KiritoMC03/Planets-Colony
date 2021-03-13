using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ResourceTradingElement : MonoBehaviour
    {
        [SerializeField] private Text _resourceName = null;
        
        public void Sale()
        {

        }

        public void SetResourceName(string name)
        {
            _resourceName.text = name;
        }
    }
}