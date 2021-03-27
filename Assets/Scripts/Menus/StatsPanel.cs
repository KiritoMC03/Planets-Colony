using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class StatsPanel : Menu
    {
        [SerializeField] private Text _moneyValue = null;
        [SerializeField] private Text _freeScoreCount = null;
        [SerializeField] private Text _maxShipsCount = null;
        [SerializeField] private Text _activeShipsCount = null;

        private const string _moneyValueText = "Деньги: ";
        private const string _freeScoreCountText = "Свободных очков: ";
        private const string _maxShipsCountText = "Максимальное число кораблей: ";
        private const string _activeShipsCountText = "Всего кораблей активно: ";

        private void Start()
        {
            SetStatsText();
        }

        public void SetStatsText()
        {
            _moneyValue.text = _moneyValueText + Converter.ValueToString(StatsSystem.Instance.GetMoney());
            _freeScoreCount.text = _freeScoreCountText + Converter.ValueToString(StatsSystem.Instance.GetScore());
            _maxShipsCount.text = _maxShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetMaxShipsCount());
            _activeShipsCount.text = _activeShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetActiveShipsCount());
        }
    }
}