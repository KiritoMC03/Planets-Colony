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

        private const string _moneyValueText = "Деньги: ";
        private const string _allResourceSoldText = "Всего ресурсов продано: ";
        private const string _maxShipsCountText = "Максимальное число кораблей: ";
        private const string _activeShipsCountText = "Всего кораблей активно: ";

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
            _moneyValue.text = _moneyValueText + _calcMoney;
            _allResourceSold.text = _calcAllResourceSold;
            _maxShipsCount.text = _calcShipsCount;
            _activeShipsCount.text = _calcactiveShipsCount;
        }

        private void CalculateStrings()
        {
            _calcMoney = Converter.ValueToString(StatsSystem.Instance.GetMoney());
            _calcAllResourceSold = _allResourceSoldText + Converter.ValueToString(ResourceSalesAccount.GetAllResourceSoldValue()) + ResourcesSystem.GetUnitsOfMeasurement();
            _calcShipsCount = _maxShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetMaxShipsCount());
            _calcactiveShipsCount = _activeShipsCountText + Converter.ValueToString(StatsSystem.Instance.GetActiveShipsCount());
        }
    }
}