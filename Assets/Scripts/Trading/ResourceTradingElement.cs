using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ResourceTradingElement : MonoBehaviour
    {
        [SerializeField] private Text _resource = null;
        [SerializeField] private Text _costText = null;
        private float _cost = 1f;
        private Resource.Type _resourceType;

        private TradingMenu _tradingMenu = null;

        private void OnEnable()
        {
            _cost = GenerateCost(1f, 100f);
            _costText.text = "Цена за шт. - " + _cost.ToString();
        }

        public void Sale()
        {
            if(_tradingMenu == null)
            {
                throw new System.Exception("TradingMenu не установлено.");
            }

            StatsSystem.Instance.AddMoney(_tradingMenu.GetResourseValue(_resourceType) * _cost);
            _tradingMenu.GetResourcesStorageLink().ResourceChange?.Invoke();
        }

        internal void SetResourceNameAndValue(string name, float value)
        {
            _resource.text = name + value;
        }

        internal void SetResourceType(Resource.Type resourceType)
        {
            this._resourceType = resourceType;
        }

        public string GetResourceName()
        {
            return _resource.text;
        }

        public Resource.Type GetResourceType()
        {
            return _resourceType;
        }

        private float GenerateCost(float min, float max)
        {
            return Random.Range(min, max);
        }

        public void SetTradingMenu(TradingMenu tradingMenu)
        {
            this._tradingMenu = tradingMenu;
        }
    }
}