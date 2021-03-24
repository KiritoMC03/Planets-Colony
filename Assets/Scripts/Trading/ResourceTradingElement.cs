﻿using System.Collections;
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

        private float _cost = 1f;
        private float _resourceValue = 0f;
        private uint _tradeValue = 0;
        private Resource.Type _resourceType;
        private bool _maySale = false;

        private TradingMenu _tradingMenu = null;

        private void OnEnable()
        {
            _cost = GenerateCost(10, 100);
            _costText.text = "Цена за шт. - " + _cost.ToString();
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
                StatsSystem.Instance.AddMoney(_tradeValue * _cost);
                _tradingMenu.GetResourcesStorageLink().ResourceChange?.Invoke();
            }
        }

        internal void SetResourceNameAndValue(string name, float value)
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
            return (uint)Random.Range(min, max);
        }

        public void SetTradingMenu(TradingMenu tradingMenu)
        {
            this._tradingMenu = tradingMenu;
        }

        public void ValidateTradeValue()
        {
            uint.TryParse(_tradeValueField.text, out _tradeValue);

            if (_tradeValue > _resourceValue)
            {
                _tradeValue = (uint)Mathf.Floor(_resourceValue);
                _tradeValueField.text = _tradeValue.ToString();
            }

            _maySale = (_tradeValue > 0 && _tradeValue <= _resourceValue);
        }
    }
}