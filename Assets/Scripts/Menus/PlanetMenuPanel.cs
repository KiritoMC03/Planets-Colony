using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlanetsColony.Utils;
using PlanetsColony.Levels;
using PlanetsColony.Factories;

namespace PlanetsColony
{
    public class PlanetMenuPanel : Menu
    {
        [SerializeField] private Text _planetName = null;
        [SerializeField] private Text _factoryLevel = null;
        [SerializeField] private Text _levelUpButton_text = null;
        [SerializeField] private Text _needMoney = null;

        private IFactory _tempFactory = null;
        private IFactoryLevel _tempFactoryLevel = null;

        private string _factoryLevelText = "Уровень завода: ";
        private string _levelUpText = "Улучшить завод.";
        private string _levelBuildText = "Построить завод.";
        private string _needMoneyText = "Нужно денег: ";

        public void Activate(IFactory planetFactory)
        {
            SetTempFields(planetFactory);
            _planetName.text = planetFactory.GetName();
            _factoryLevel.text = _factoryLevelText + _tempFactoryLevel.GetLevel();
            _levelUpButton_text.text = (_tempFactoryLevel.GetLevel() > 0) ? _levelUpText : _levelBuildText;
            _needMoney.text = _needMoneyText + Converter.ValueToString(FactoryLevelling.CalculateNeedMoney(_tempFactoryLevel.GetLevel() + 1));
        }

        public void UpdateText()
        {
            Activate(_tempFactory);
        }

        private void SetTempFields(IFactory factory)
        {
            _tempFactory = factory;
            _tempFactoryLevel = factory.GetLinkToIFactoryLevel();
        }
    }
}