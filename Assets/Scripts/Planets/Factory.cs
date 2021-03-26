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
        [SerializeField] private SpaceshipsPort _spaceshipsPort = null;

        private Transform _transform = null;
        private CargoGenerator _cargoGenerator = null;
        private bool _isActive = false;
        private bool _canLevelUp = true;
        private uint _resourceValueMultiplier = 0;

        private void Awake()
        {
            _transform = transform;
            _cargoGenerator = GetComponent<CargoGenerator>();
            if (_factorySprite == null)
            {
                throw new Exception("Установите поле Factory Sprite.");
            }
            if (_spaceshipsPort == null)
            {
                throw new Exception("Установите поле Spaceships Port.");
            }

            if (_level > 0)
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
            _canLevelUp = true;
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
            if(_level == 0)
            {
                _spaceshipsPort.SendBuilderShip(this);
                _canLevelUp = false;
            }
            else if(_level > 0)
            {
                IncreaseLevel();
            }
        }

        public bool GetIsActive()
        {
            return _isActive;
        }

        internal void IncreaseLevel()
        {
            _level++;
        }
        internal void SetLevel(uint level)
        {
            this._level = level;
        }

        public bool IsCanLevelUp()
        {
            return _canLevelUp;
        }

        private uint CalculateResourceValueMultiplier()
        {
            return _resourceValueMultiplier = _level;
        }

        public void Build(float delay)
        {
            StartCoroutine(FactoryBuildRoutine(delay));
        }

        private IEnumerator FactoryBuildRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetLevel(1);
            Activate();
        }
    }
}