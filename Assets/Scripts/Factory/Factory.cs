using UnityEngine;
using System.Collections;
using System;
using PlanetsColony.Resources;
using UnityEngine.Events;

namespace PlanetsColony
{
    [RequireComponent(typeof(CargoGenerator))]
    public class Factory : MonoBehaviour
    {
        public UnityEvent OnActivate;

        [SerializeField] public uint _level = 0;
        [SerializeField] private uint _minGeneratedResource = 0;
        [SerializeField] private uint _maxGeneratedResource = 100;
        [SerializeField] private SpriteRenderer _factorySprite = null;
        [SerializeField] private SpaceshipsPort _spaceshipsPort = null;
        [Header("Идентификатор. На английском.")]
        [SerializeField] private string _id = "";

        private Transform _transform = null;
        private CargoGenerator _cargoGenerator = null;
        private bool _isActive = false;
        private bool _canLevelUp = true;
        private uint _resourceValueMultiplier = 0;

        private string _levelKey = "_level";

        private void OnApplicationQuit()
        {
            SaveLevel();
        }

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
            CheckOtherFactoriesID();
        }

        private void Start()
        {
            LoadLevel();

            if (_level > 0)
            {
                Activate();
            }
            else
            {
                Disactivate();
            }
        }

#region LevelWork
        private void SaveLevel()
        {
            PlayerPrefs.SetFloat(_id + _levelKey, _level);
        }

        private void LoadLevel()
        {
            _level = Convert.ToUInt32(PlayerPrefs.GetFloat(_id + _levelKey));
        }

        internal void LevelUp()
        {
            if (_level == 0)
            {
                _spaceshipsPort.SendBuilderShip(this);
                _canLevelUp = false;
            }
            else if (_level > 0)
            {
                IncreaseLevel();
            }
        }

        internal void IncreaseLevel()
        {
            _level++;
            SaveLevel();
        }
#endregion

#region BuildWork
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
        #endregion

#region ConditionWork
        public void Activate()
        {
            _isActive = true;
            _canLevelUp = true;
            _factorySprite.gameObject.SetActive(true);
            OnActivate?.Invoke();
        }

        public void Disactivate()
        {
            _isActive = false;
            _factorySprite.gameObject.SetActive(false);
        }
        #endregion

#region CargoWork
        public void SendCargo(CargoHandler ship, Resource.Type resourceType)
        {
            CalculateResourceValueMultiplier();
            ship.AcceptCargo(_cargoGenerator.GenerateCargo(resourceType, 
                _minGeneratedResource * _resourceValueMultiplier, 
                _maxGeneratedResource * _resourceValueMultiplier));
        }
        #endregion

#region Utils
        private float CalculateResourceValueMultiplier()
        {
            return _resourceValueMultiplier = _level;
        }

        private static void CheckOtherFactoriesID()
        {
            var temp = FindObjectsOfType<Factory>();
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    if (i == j) continue;
                    if (temp[i].GetID() == temp[j].GetID())
                    {
                        throw new Exception($"У заводов планет должны быть уникальные идентификаторы! \n {temp[i].gameObject} совпадает с {temp[j].gameObject}");
                    }
                }
            }
        }
#endregion

#region GettersSetters
        internal void SetLevel(uint level)
        {
            this._level = level;
            SaveLevel();
        }

        public bool IsCanLevelUp()
        {
            return _canLevelUp;
        }
        public bool GetIsActive()
        {
            return _isActive;
        }

        public uint GetLevel()
        {
            return _level;
        }

        public string GetID()
        {
            return _id;
        }
#endregion
    }
}