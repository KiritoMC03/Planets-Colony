using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ResourceTradingElement : MonoBehaviour
    {
        [SerializeField] private Text _resourceName = null;
        [SerializeField] private Text _oneCost = null;
        [SerializeField] private InputField _tradeValueField = null;

        private static string _oneCostText = "Цена за шт.: ";

        private uint _cost = 1;
        private ulong _resourceValue = 0;
        private ulong _tradeValue = 0;
        private Resource.Type _resourceType;
        private bool _maySale = false;

        [SerializeField] private TradingMenu _tradingMenu = null;

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

        #region TradeWork
        public void Sale()
        {
            CheckTradingMenu();
            ValidateTradeValue();
            if (_maySale)
            {
                Trade(_tradeValue);
            }
        }

        public void SaleAll()
        {
            if (CheckTradingMenu())
            {
                Trade(_resourceValue);
            }
        }

        public void UpdateCost()
        {
            if(ResourcesSystem.Instance == null)
            {
                throw new Exception("Не найден ни один объект ResourcesSystem с корректной ссылкой Instance.");
            }

            var min = ResourcesSystem.Instance.GetMinCost(_resourceType);
            var max = ResourcesSystem.Instance.GetMaxCost(_resourceType);
            SetCost(min, max);
        }

        private void Trade(ulong value)
        {
            var money = _tradingMenu.GetResourceToTrade(_resourceType, value) * _cost;
            StatsSystem.Instance.AddMoney(money);
            _tradingMenu.GetResourcesStorageLink().ResourceChange?.Invoke();
        }

        #endregion

        #region TextWork
        internal void SetResourceNameAndValue(string name, ulong value)
        {
            _resourceValue = value;
            _resourceName.text = name + Converter.ValueToString(value) + ResourcesSystem.GetUnitsOfMeasurement();
        }
        #endregion

        #region GettersSetters
        public void SetTradingMenu(TradingMenu tradingMenu)
        {
            this._tradingMenu = tradingMenu;
        }

        private void SetCost(uint min, uint max)
        {
            _cost = GenerateCost(min, max);
            _oneCost.text = _oneCostText + _cost.ToString();
        }

        public string GetResourceName()
        {
            return _resourceName.text;
        }

        public Resource.Type GetResourceType()
        {
            return _resourceType;
        }

        internal void SetResourceType(Resource.Type resourceType)
        {
            this._resourceType = resourceType;
        }
        #endregion

        #region PreTradeWork
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

        private bool CheckTradingMenu()
        {
            if (_tradingMenu == null)
            {
                throw new System.Exception("TradingMenu не установлено.");
            }
            return true;
        }

        private uint GenerateCost(uint min, uint max)
        {

            tempCost = 100;
                /*
                (uint)
                (Mathf.Sqrt(
                    _tradingMenu.GetResourceMarketValue(_resourceType)) 
                * UnityEngine.Random.Range(min, max));
                */
            //tempCost = Convert.ToUInt32(Mathf.Clamp(tempCost, min, max));
            return tempCost;
        }
        #endregion
    }
}