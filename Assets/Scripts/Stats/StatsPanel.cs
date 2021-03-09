using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class StatsPanel : MonoBehaviour
    {
        [SerializeField] private Text _maxShipsCount = null;
        [SerializeField] private Text _activeShipsCount = null;

        private const string _maxShipsCountText = "Максимальное число кораблей: ";
        private const string _activeShipsCountText = "Всего кораблей активно: ";

        private void Start()
        {
            SetStatsText();
        }

        public void SetStatsText()
        {
            _maxShipsCount.text = _maxShipsCountText + StatsSystem.Instance.GetMaxShipsCount();
            _activeShipsCount.text = _activeShipsCountText + StatsSystem.Instance.GetActiveShipsCount();
        }
    }
}