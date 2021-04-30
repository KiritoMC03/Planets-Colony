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

        private const string FACTOY_LEVEL_TEXT = "Уровень завода: ";
        private const string LEVEL_UP_TEXT = "Улучшить завод.";
        private const string FACTORY_BUILD_TEXT = "Построить завод.";
        private const string NEED_MONEY_TEXT = "Нужно денег: ";

        public void Activate(IFactory planetFactory)
        {
            SetTempFields(planetFactory);
            _planetName.text = planetFactory.GetName();
            _factoryLevel.text = FACTOY_LEVEL_TEXT + _tempFactoryLevel.GetLevel();
            _levelUpButton_text.text = (_tempFactoryLevel.GetLevel() > 0) ? LEVEL_UP_TEXT : FACTORY_BUILD_TEXT;
            _needMoney.text = NEED_MONEY_TEXT + Converter.ValueToString(FactoryLevelling.CalculateNeedMoney(_tempFactoryLevel.GetLevel() + 1));
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