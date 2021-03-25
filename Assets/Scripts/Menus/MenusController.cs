using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class MenusController : MonoBehaviour
    {
        [Header("Панели-меню под контролем.")]
        [SerializeField] private Menu[] _menusList = null;

        public void DisableAllBut(Menu exception)
        {
            for (int i = 0; i < _menusList.Length; i++)
            {
                if(_menusList[i] != exception)
                {
                    _menusList[i].gameObject.SetActive(false);
                }
            }
        }

        public void Activate(Menu menu)
        {
            menu.gameObject.SetActive(true);
        }

        public void ActivateAll()
        {
            for (int i = 0; i < _menusList.Length; i++)
            {
                _menusList[i].gameObject.SetActive(true);
            }
        }

        public void RevertCondition()
        {
            for (int i = 0; i < _menusList.Length; i++)
            {
                _menusList[i].gameObject.SetActive(!_menusList[i].gameObject.activeInHierarchy);
            }
        }
    }
}