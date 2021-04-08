using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace PlanetsColony.Levels
{
    public class FactoryLevelling : MonoBehaviour
    {
        [SerializeField] private ulong _moneyForBuildFactory = (ulong)Mathf.Pow(10, 10);
        private static BigInteger _moneyForBuild;

        private void Awake()
        {
            _moneyForBuild = _moneyForBuildFactory;
        }

        public static BigInteger CalculateNeedMoney(uint level)
        {
            if (level == 1)
            {
                return _moneyForBuild;
            }
            try
            {
                return (BigInteger.Pow(6, Convert.ToInt32(level)) * 3000000);
            }
            catch
            {
                throw new Exception("Exception!");
            }
        }

        public ulong GetMoneyForBuildFactory()
        {
            return _moneyForBuildFactory;
        }
    }
}