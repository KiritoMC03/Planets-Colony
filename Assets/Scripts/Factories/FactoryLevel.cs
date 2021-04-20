using PlanetsColony.Spaceships;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony.Factories
{
    [RequireComponent(typeof(IFactory))]
    public class FactoryLevel : MonoBehaviour, IFactoryLevel
    {
        [SerializeField] public uint _level = 0;
        [SerializeField] private SpaceshipsPort _spaceshipsPort = null;
        private IFactory _factory = null;
        private bool _canLevelUp = true;
        private string _keyForSaveLoad = "_level";

        private void OnApplicationQuit()
        {
            SaveLevel();
        }

        private void Awake()
        {
            _factory = GetComponent<Factory>();
            if (_factory == null)
            {
                throw new NullReferenceException("No component that implements the IFactory interface was found.");
            }
            if (_spaceshipsPort == null)
            {
                throw new Exception("Установите поле Spaceships Port.");
            }
        }

        private void Start()
        {
            LoadLevel();

            if (_level > 0)
            {
                _factory.Activate();
            }
            else
            {
                _factory.Disactivate();
            }
        }

        private void SaveLevel()
        {
            PlayerPrefs.SetFloat(_factory.GetID() + _keyForSaveLoad, _level);
        }

        private void LoadLevel()
        {
            _level = Convert.ToUInt32(PlayerPrefs.GetFloat(_factory.GetID() + _keyForSaveLoad));
        }

        public void LevelUp()
        {
            if (_level == 0)
            {
                _spaceshipsPort.SendBuilderShip(_factory);
                //_canLevelUp = false;
            }
            else if (_level > 0)
            {
                IncreaseLevel();
            }
        }

        private void IncreaseLevel()
        {
            _level++;
            SaveLevel();
        }

        public uint GetLevel()
        {
            return _level;
        }

        public void SetLevel(uint level)
        {
            this._level = level;
            SaveLevel();
        }

        public void SetCanLevelUp(bool value)
        {
            _canLevelUp = value;
        }

        public bool IsCanLevelUp()
        {
            return _canLevelUp;
        }
    }
}