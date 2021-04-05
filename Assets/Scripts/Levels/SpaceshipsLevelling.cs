using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony.Levels
{
    public class SpaceshipsLevelling : MonoBehaviour
    {
        public UnityEvent OnSpaceshipsLevelUp;

        public static SpaceshipsLevelling Instance = null;

        [SerializeField] private int _maxLevel = 16;
        [SerializeField] private Sprite[] _spriteForLevels = null;
        [SerializeField] private static Sprite[] _spriteForLevelsa = null;
        private int _currentLevel = 1;

        private void Awake()
        {
            Instance = this;
            if (_maxLevel < 1)
            {
                throw new Exception("MaxLevel must be greater than zero.");
            }

            if(_spriteForLevels == null || _spriteForLevels.Length == 0)
            {
                throw new Exception("Need one spaceship sprite or more.");
            }
        }

        public Sprite GetCurrentSprite()
        {
            try
            {
                return _spriteForLevels[_currentLevel - 1];
            }
            catch
            {
                throw new Exception($"");
            }
        }

        public Sprite TryGetCurrentSprite()
        {
            if (_currentLevel - 1 < _spriteForLevels.Length && 
                _spriteForLevels[_currentLevel - 1] != null)
            {
                return _spriteForLevels[_currentLevel - 1];
            }

            return null;
        }

        public int GetMaxLevel()
        {
            return _maxLevel;
        }

        public int GetCurrentLevel()
        {
            return _currentLevel;
        }

        public BigInteger CalculateMoneyForLevelUp()
        {
            return (BigInteger.Pow(6, _currentLevel + 11));
        }

        private bool CheckNeedMoney()
        {
            return (StatsSystem.Instance.GetMoney() >= CalculateMoneyForLevelUp());
        }

        public void LevelUp()
        {
            if (_currentLevel < _maxLevel && CheckNeedMoney())
            {
                StatsSystem.Instance.UseMoney(CalculateMoneyForLevelUp());
                _currentLevel++;
                OnSpaceshipsLevelUp?.Invoke();
            }
        }
    }
}