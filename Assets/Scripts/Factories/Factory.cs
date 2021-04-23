using UnityEngine;
using System.Collections;
using System;
using PlanetsColony.Resources;
using UnityEngine.Events;
using PlanetsColony.Utils;
using PlanetsColony.Cargos;
using PlanetsColony.Cargos.CargoHandlingByShip;

namespace PlanetsColony.Factories
{
    [RequireComponent(typeof(ICargoGenerator), typeof(IFactoryLevel))]
    public class Factory : MonoBehaviour, IFactory
    {
        public UnityEvent OnActivate;

        [SerializeField] private uint _minGeneratedResource = 0;
        [SerializeField] private uint _maxGeneratedResource = 100;
        [SerializeField] private SpriteRenderer _factorySprite = null;
        [SerializeField] private string _planetName = "Марс";
        [Header("Идентификатор. На английском.")]
        [SerializeField] private string _id = "";

        private Transform _transform = null;
        private ICargoGenerator _cargoGenerator = null;
        private IFactoryLevel _factoryLevel = null;
        private bool _isActive = false;

        private void Awake()
        {
            InitFields();
            CheckOtherFactoriesID();
        }

        public void Activate()
        {
            _isActive = true;
            _factoryLevel.SetCanLevelUp(true);
            _factorySprite.gameObject.SetActive(true);
            OnActivate?.Invoke();
        }

        public void Disactivate()
        {
            _isActive = false;
            _factorySprite.gameObject.SetActive(false);
        }

        public void AddListenerForOnActivate(UnityAction call)
        {
            OnActivate.AddListener(call);
        }

        public void SendCargo(ISpaceshipCargoHandler ship, Resource.Type resourceType)
        {
            var tempCargo = _cargoGenerator.GenerateCargo(resourceType,
                _minGeneratedResource,
                _maxGeneratedResource,
                MultiplierCalculator.CalculateGeneratedResourceMultiplier(_factoryLevel.GetLevel()));
            ship.AcceptCargo(tempCargo);
        }

        public bool GetIsActive()
        {
            return _isActive;
        }

        public string GetID()
        {
            return _id;
        }

        public Transform GetUnityTransform()
        {
            return _transform;
        }

        public string GetName()
        {
            return _planetName;
        }

        public IFactoryLevel GetLinkToIFactoryLevel()
        {
            return _factoryLevel;
        }

        private void InitFields()
        {
            _transform = transform;
            _cargoGenerator = GetComponent<ICargoGenerator>();
            _factoryLevel = GetComponent<IFactoryLevel>();
            if (_factorySprite == null)
            {
                throw new Exception("Установите поле Factory Sprite.");
            }
            if (_factoryLevel == null)
            {
                throw new NullReferenceException("No component that implements the IFactoryLevel interface was found.");
            }
            if (_cargoGenerator == null)
            {
                throw new NullReferenceException("No component that implements the ICargoGenerator interface was found.");
            }
        }

        #region Utils

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
    }
}