using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using PlanetsColony.Levels;
using PlanetsColony.Factories;

namespace PlanetsColony
{
    public class PlanetMenuHandler : MonoBehaviour
    {
        public UnityEvent OnPlanetClick;

        [SerializeField] private PlanetMenuPanel _panel = null;
        private Factory _currentPlanetWithFactory = null;
        private Camera _mainCamera = null;
        // временные переменные здесь:
        private BigInteger _tempNeedMoney = 0;
        private RaycastHit2D _temphit;

        private void Awake()
        {
            _mainCamera = Camera.main;
            if(_panel == null)
            {
                throw new Exception("Panel field must not be null.");
            }
            _panel.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _temphit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Input.mousePosition));
                if (_temphit)
                {
                    _currentPlanetWithFactory = _temphit.collider.GetComponent<Factory>();
                    if(_currentPlanetWithFactory != null)
                    {
                        _panel.gameObject.SetActive(true);
                        _panel.Activate(_currentPlanetWithFactory);
                        OnPlanetClick?.Invoke();
                    }
                }
            }
        }
        
        public void LevelUp()
        {
            _tempNeedMoney = FactoryLevelling.CalculateNeedMoney(_currentPlanetWithFactory.GetLevel() + 1);
            if (_currentPlanetWithFactory.IsCanLevelUp() && StatsSystem.Instance.GetMoney() >= _tempNeedMoney)
            {
                StatsSystem.Instance.UseMoney(_tempNeedMoney);
                _currentPlanetWithFactory.LevelUp();
                _panel.UpdateText();
            }
        }
    }
}