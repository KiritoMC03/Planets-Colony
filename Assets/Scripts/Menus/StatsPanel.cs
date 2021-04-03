using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class StatsPanel : Menu
    {
        [SerializeField] private Text _moneyValue = null;
        [SerializeField] private Text _allResourceSold = null;
        [SerializeField] private Text _maxShipsCount = null;
        [SerializeField] private Text _activeShipsCount = null;

        private const string _moneyValueText = "Деньги: ";
        private const string _allResourceSoldText = "Всего ресурсов продано: ";
        private const string _maxShipsCountText = "Максимальное число кораблей: ";
        private const string _activeShipsCountText = "Всего кораблей активно: ";

        private void Awake()
        {
            StatsSystem.Instance.OnShipCountChange.AddListener(SetStatsText);
            StatsSystem.Instance.OnMoneyValueChange.AddListener(SetStatsText);
        }

        private void Start()
        {
            SetStatsText();
        }

        public void SetStatsText()
        {
            _moneyValue.text = _moneyValueText + Converter.ValueToString(StatsSystem.Instance.GetMoney());
            _allResourceSold.text = _allResourceSoldText + Converter.ValueToString(StatsSystem.Instance.GetAllResourceSoldValue());
            _maxShipsCount.text = _maxShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetMaxShipsCount());
            _activeShipsCount.text = _activeShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetActiveShipsCount());
        }
    }
}