using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class PlanetMenuPanel : MonoBehaviour
    {
        [SerializeField] private Text _planetName = null;
        [SerializeField] private Text _factoryLevel = null;

        private Factory tempFactory = null;

        private string _factoryLevelText = "Уровень завода: ";

        public void Activate(Factory planetFactory)
        {
            tempFactory = planetFactory;
            _planetName.text = planetFactory.gameObject.name;
            _factoryLevel.text = _factoryLevelText + planetFactory.GetLevel();
        }

        public void UpdateText()
        {
            Activate(tempFactory);
        }
    }
}