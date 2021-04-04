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

        public static BigInteger CalculateNeedMoney(uint level)
        {
            if (level == 1)
            {
                return _moneyForBuild;
            }
            return (BigInteger)(2 * Mathf.Pow(level, 6.252f) + 149999848);
        }
    }
}