using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class PlanetMenu : MonoBehaviour
    {
        [SerializeField] private StatsSystem _statsSystem = null;
        [SerializeField] private PlanetMenuPanel _panel = null;

        private GameObject _currentPlanet = null;
        private Factory _planetFactory = null;
        private Camera _mainCamera = null;

        private void Awake()
        {
            _mainCamera = Camera.main;

            if(_panel == null)
            {
                throw new Exception("Необходимо установить поле Panel.");
            }

            if (_statsSystem == null)
            {
                throw new Exception("Требуется установить поле компонента StatsSystem!");
            }

            _panel.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Input.mousePosition));

                if (hit)
                {
                    Debug.Log("RaycastEnter!");
                    _currentPlanet = hit.collider.gameObject;
                    _panel.gameObject.SetActive(true);
                    Debug.Log("_panel: " + _panel);
                    _panel.Activate(_currentPlanet.GetComponent<Factory>());
                }

                /*
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawLine(_mainCamera.transform.position, hit.point);
                    Debug.Log("RaycastEnter!");

                    _currentPlanet = hit.collider.gameObject;
                    _panel.gameObject.SetActive(true);
                    Debug.Log("_panel: " + _panel);
                    _panel.Activate(_currentPlanet.GetComponent<Factory>());
                }
                */
            }
        }
        
        public void LevelUp()
        {
            if(_statsSystem.GetScore() > 0)
            {
                _planetFactory = _currentPlanet.GetComponent<Factory>();
                _planetFactory.LevelUp();
                _statsSystem.UseScore();
                _panel.UpdateText();
            }
        }
    }
}