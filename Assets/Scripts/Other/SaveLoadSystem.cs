using PlanetsColony.Levels;
using PlanetsColony.Trading;
using System;
using System.Numerics;
using UnityEngine;

namespace PlanetsColony
{
    public class SaveLoadSystem : MonoBehaviour
    {
        public static SaveLoadSystem Instance = null;

        [SerializeField] private FactoryLevelling _factoryLevelling = null;

        private static string MONEY_VALUE_KEY = "moneyValue";
        private string _tempMoneyValue = "";
        private static string ALLRESOURCE_SOLD_VALUE_KEY = "resourceSoldValue"; 
        private string _tempResourceSoldValue = "";

        private void Awake()
        {
            Instance = this;
            if (_factoryLevelling == null)
            {
                throw new Exception("FactoryLevelling field must not be null.");
            }
        }

        private void Start()
        {
            StatsSystem.Instance.OnMoneyValueChange.AddListener(SaveMoney);
            StatsSystem.Instance.OnMoneyValueChange.AddListener(SaveAllResourceSoldValue);
        }

        public void DeleteAllPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            StatsSystem.Instance.SetMoney(0);
        }

        public void SaveMoney()
        {
            _tempMoneyValue = StatsSystem.Instance.GetMoney().ToString();
            PlayerPrefs.SetString(MONEY_VALUE_KEY, _tempMoneyValue);
        }
        public BigInteger LoadMoney()
        {
            BigInteger returnValue = _factoryLevelling.GetMoneyForBuildFactory();
            if (PlayerPrefs.HasKey(MONEY_VALUE_KEY))
            {
                returnValue = BigInteger.Parse(PlayerPrefs.GetString(MONEY_VALUE_KEY));
            }
            else
            {
                Debug.LogWarning("В PlayerPrefs не найдет ключ MONEY_VALUE_KEY.");
            }
			return returnValue;
        }

        public void SaveAllResourceSoldValue()
        {
            _tempResourceSoldValue = ResourceSalesAccount.GetAllResourceSoldValue().ToString();
            PlayerPrefs.SetString(ALLRESOURCE_SOLD_VALUE_KEY, _tempResourceSoldValue);
        }
        public BigInteger LoadAllResourceSoldValue()
        {
            BigInteger returnValue = 0;
            if (PlayerPrefs.HasKey(ALLRESOURCE_SOLD_VALUE_KEY))
            {
                returnValue = BigInteger.Parse(PlayerPrefs.GetString(ALLRESOURCE_SOLD_VALUE_KEY));
            }
            else
            {
                Debug.LogWarning("В PlayerPrefs не найдет ключ MONEY_VALUE_KEY.");
            }

            return returnValue;
        }
    }
}
