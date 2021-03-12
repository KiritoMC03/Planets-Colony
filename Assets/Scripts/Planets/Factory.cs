using UnityEngine;
using System.Collections;
using System;

namespace PlanetsColony
{
    public class Factory : MonoBehaviour
    {
        [SerializeField] private int _level = 0;
        [SerializeField] private SpriteRenderer _factorySprite = null;
        
        private bool _isActive = false;

        private void Awake()
        {
            if(_factorySprite == null)
            {
                throw new Exception("Установите поле Factory Sprite.");
            }

            if(_level > 0)
            {
                Activate();
            }
            else
            {
                Disactivate();
            }
        }

        public void Activate()
        {
            _isActive = true;
            _factorySprite.gameObject.SetActive(true);
        }

        public void Disactivate()
        {
            _isActive = false;
            _factorySprite.gameObject.SetActive(false);
        }

        public int GetLevel()
        {
            return _level;
        }

        internal void LevelUp()
        {
            _level++;
        }

        public bool GetIsActive()
        {
            return _isActive;
        }
    }
}