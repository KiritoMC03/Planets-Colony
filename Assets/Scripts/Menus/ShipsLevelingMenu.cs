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

        private const string CURRENT_LEVEL_TEXT = "Уровень развития кораблей: ";
        private const string MAX_LEVEL_TEXT = "Предельный уровень развития кораблей: ";
        private const string LEVELUP_COST_TEXT = "Стоимость развития кораблей: ";

        private void Start()
        {
            SpaceshipsLevelling.Instance.OnSpaceshipsLevelUp.AddListener(UpdateText);
            SetText();
        }

        private void SetText()
        {
            _currentLevel.text = CURRENT_LEVEL_TEXT + SpaceshipsLevelling.Instance.CurrentLevel;
            _maxLevel.text = MAX_LEVEL_TEXT + SpaceshipsLevelling.Instance.MaxLevel;
            _levelUpCost.text = LEVELUP_COST_TEXT + Converter.ValueToString(SpaceshipsLevelling.Instance.CalculateMoneyForLevelUp());
        }

        public void UpdateText()
        {
            SetText();
        }
    }
}