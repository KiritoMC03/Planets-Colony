using System;
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
        [SerializeField] private InputField _tradeValueField = null;

        private uint _cost = 1;
        private ulong _resourceValue = 0;
        private ulong _tradeValue = 0;
        private Resource.Type _resourceType;
        private bool _maySale = false;

        private TradingMenu _tradingMenu = null;

        private uint tempCost = 0;

        private void OnEnable()
        {
            UpdateCost();
            StatsSystem.Instance.OnMoneyValueChange.AddListener(UpdateCost);
        }

        private void OnDisable()
        {
            StatsSystem.Instance.OnMoneyValueChange.RemoveListener(UpdateCost);
        }

        public void Sale()
        {
            if(_tradingMenu == null)
            {
                throw new System.Exception("TradingMenu не установлено.");
            }

            ValidateTradeValue();
            if (_maySale)
            {
                var money = _tradingMenu.GetResourceToTrade(_resourceType, _tradeValue) * _cost;
                Debug.Log("_tradeValue: " + _tradeValue);
                StatsSystem.Instance.AddMoney(money);
                _tradingMenu.GetResourcesStorageLink().ResourceChange?.Invoke();
            }
        }

        internal void SetResourceNameAndValue(string name, ulong value)
        {
            _resourceValue = value;
            _resource.text = name + _resourceValue;
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

        private uint GenerateCost(uint min, uint max)
        {
            tempCost = Convert.ToUInt32(Mathf.Clamp((55 * _tradingMenu.GetResourceMarketValue(_resourceType) / 10), 1, uint.MaxValue));
            tempCost = Convert.ToUInt32(Mathf.Clamp(tempCost, min, max));
            return tempCost;
        }

        public void SetTradingMenu(TradingMenu tradingMenu)
        {
            this._tradingMenu = tradingMenu;
        }

        public void ValidateTradeValue()
        {
            ulong.TryParse(_tradeValueField.text, out _tradeValue);

            if (_tradeValue > _resourceValue)
            {
                _tradeValue = (ulong)Mathf.Floor(_resourceValue);
                _tradeValueField.text = _tradeValue.ToString();
            }

            _maySale = (_tradeValue > 0 && _tradeValue <= _resourceValue);
        }

        public void SetCost(uint min, uint max)
        {
            _cost = GenerateCost(min, max);
            _costText.text = "Цена за шт.: " + _cost.ToString();
        }

        public void UpdateCost()
        {
            SetCost(10, 1000);
        }
    }
}