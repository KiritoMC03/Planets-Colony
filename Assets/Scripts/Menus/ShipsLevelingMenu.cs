using PlanetsColony.Levels;
using PlanetsColony.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class ShipsLevelingMenu : Menu
    {
        [SerializeField] private Text _currentLevel = null;
        [SerializeField] private Text _maxLevel = null;
        [SerializeField] private Text _levelUpCost = null;

        private string _currentLevelText = "Уровень развития кораблей: ";
        private string _maxLevelText = "Предельный уровень развития кораблей: ";
        private string _levelUpCostText = "Стоимость развития кораблей: ";

        private void Start()
        {
            SpaceshipsLevelling.Instance.OnSpaceshipsLevelUp.AddListener(UpdateText);
            SetText();
        }

        private void SetText()
        {
            _currentLevel.text = _currentLevelText + SpaceshipsLevelling.Instance.GetCurrentLevel();
            _maxLevel.text = _maxLevelText + SpaceshipsLevelling.Instance.GetMaxLevel();
            _levelUpCost.text = _levelUpCostText + Converter.ValueToString(SpaceshipsLevelling.Instance.CalculateMoneyForLevelUp());
        }

        public void UpdateText()
        {
            SetText();
        }
    }
}