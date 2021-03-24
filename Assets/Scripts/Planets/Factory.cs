using UnityEngine;
using System.Collections;
using System;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoGenerator))]
    public class Factory : MonoBehaviour
    {
        [SerializeField] private uint _level = 0;
        [SerializeField] private uint _minGeneratedResource = 0;
        [SerializeField] private uint _maxGeneratedResource = 100;
        [SerializeField] private SpriteRenderer _factorySprite = null;

        private CargoGenerator _cargoGenerator = null;
        private bool _isActive = false;
        private uint _resourceValueMultiplier = 0;

        private void Awake()
        {
            _cargoGenerator = GetComponent<CargoGenerator>();
            if (_factorySprite == null)
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

        public void SendCargo(CargoHandler ship, Resource.Type resourceType)
        {
            CalculateResourceValueMultiplier();
            ship.AcceptCargo(_cargoGenerator.GenerateCargo(resourceType, 
                _minGeneratedResource * _resourceValueMultiplier, 
                _maxGeneratedResource * _resourceValueMultiplier));
        }

        public uint GetLevel()
        {
            return _level;
        }

        internal void LevelUp()
        {
            _level++;
            Activate();
        }

        public bool GetIsActive()
        {
            return _isActive;
        }

        private uint CalculateResourceValueMultiplier()
        {
            return _resourceValueMultiplier = _level;
        }
    }
}