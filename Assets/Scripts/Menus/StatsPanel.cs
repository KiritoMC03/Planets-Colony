using UnityEngine;
using UnityEngine.UI;
using PlanetsColony.Utils;
using PlanetsColony.Trading;

namespace PlanetsColony
{
    public class StatsPanel : Menu
    {
        [SerializeField] private Text _moneyValue = null;
        [SerializeField] private Text _allResourceSold = null;
        [SerializeField] private Text _maxShipsCount = null;
        [SerializeField] private Text _activeShipsCount = null;

        private const string MONEY_VALUE_TEXT = "Деньги: ";
        private const string ALL_RESOURCE_SOLD_TEXT = "Всего ресурсов продано: ";
        private const string MAX_SHIP_COUNT_TEXT = "Максимальное число кораблей: ";
        private const string ACTIVE_SHIPS_COUNT_TEXT = "Всего кораблей активно: ";

        private string _calcMoney = null;
        private string _calcAllResourceSold = null;
        private string _calcShipsCount = null;
        private string _calcactiveShipsCount = null;

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
            CalculateStrings();
            _moneyValue.text = MONEY_VALUE_TEXT + _calcMoney;
            _allResourceSold.text = _calcAllResourceSold;
            _maxShipsCount.text = _calcShipsCount;
            _activeShipsCount.text = _calcactiveShipsCount;
        }

        private void CalculateStrings()
        {
            _calcMoney = Converter.ValueToString(StatsSystem.Instance.GetMoney());
            _calcAllResourceSold = ALL_RESOURCE_SOLD_TEXT + Converter.ValueToString(ResourceSalesAccount.GetAllResourceSoldValue()) + ResourcesSystem.GetUnitsOfMeasurement();
            _calcShipsCount = MAX_SHIP_COUNT_TEXT + Converter.ValueToString(StatsSystem.Instance.GetMaxShipsCount());
            _calcactiveShipsCount = ACTIVE_SHIPS_COUNT_TEXT + Converter.ValueToString(StatsSystem.Instance.GetActiveShipsCount());
        }
    }
}