using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace PlanetsColony.Levels
{
    public class LevelsSystem : MonoBehaviour
    {
        [SerializeField] private ulong _moneyForBuildFactory = (ulong)Mathf.Pow(10, 9);
        private static BigInteger _moneyForBuild;

        private void Awake()
        {
            _moneyForBuild = _moneyForBuildFactory;
        }

        public static BigInteger CalculateNeedMoney(ulong level)
        {
            if (level == 1)
            {
                return _moneyForBuild;
            }
            return (2 * BigInteger.Pow(level, 6) + 149999848);
        }
    }
}