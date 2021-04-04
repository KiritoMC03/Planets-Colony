using PlanetsColony.Trading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PlanetsColony
{
    public class SaveLoadSystem : MonoBehaviour
    {
        public static SaveLoadSystem Instance = null;

        private static string MONEY_VALUE_KEY = "moneyValue";
        private string _tempMoneyValue = "";
        private static string ALLRESOURCE_SOLD_VALUE_KEY = "resourceSoldValue"; 
        private string _tempResourceSoldValue = "";

        private void Awake()
        {
            Instance = this;
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
            BigInteger returnValue = 30000000000;
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
        public ulong LoadAllResourceSoldValue()
        {
            ulong returnValue = 0;
            if (PlayerPrefs.HasKey(ALLRESOURCE_SOLD_VALUE_KEY))
            {
                returnValue = ulong.Parse(PlayerPrefs.GetString(ALLRESOURCE_SOLD_VALUE_KEY));
            }
            else
            {
                Debug.LogWarning("В PlayerPrefs не найдет ключ MONEY_VALUE_KEY.");
            }

            return returnValue;
        }
    }
}
