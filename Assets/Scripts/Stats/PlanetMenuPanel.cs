using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class PlanetMenuPanel : MonoBehaviour
    {
        [SerializeField] private Text _planetName = null;
        [SerializeField] private Text _factoryLevel = null;
        [SerializeField] private Text _levelUpButton_text = null;
        [SerializeField] private Text _freeScore = null;

        private Factory tempFactory = null;

        private string _factoryLevelText = "Уровень завода: ";
        private string _levelUpText = "Улучшить завод.";
        private string _levelBuildText = "Построить завод.";
        private string _freeScoreText = "Свободных очков: ";

        public void Activate(Factory planetFactory)
        {
            tempFactory = planetFactory;
            _planetName.text = planetFactory.gameObject.name;
            _factoryLevel.text = _factoryLevelText + planetFactory.GetLevel();
            _levelUpButton_text.text = (planetFactory.GetLevel() > 0) ? _levelUpText : _levelBuildText;
            _freeScore.text = _freeScoreText + StatsSystem.Instance.GetScore();
        }

        public void UpdateText()
        {
            Activate(tempFactory);
        }
    }
}