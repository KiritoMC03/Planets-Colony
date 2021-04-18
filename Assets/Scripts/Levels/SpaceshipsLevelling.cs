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
        public int MaxLevel 
        { 
            get => _maxLevel; 
            private set => _maxLevel = value;
        }
        public int CurrentLevel 
        { 
            get => _currentLevel;
            private set => _currentLevel = value; 
        }
        [SerializeField] private int _maxLevel = 16;
        [SerializeField] private int _currentLevel = 1;
        [SerializeField] private SpaceshipsLevelSprites _spaceshipsLevelSprites = null;

        private void Awake()
        {
            Instance = this;
            if (MaxLevel < 1)
            {
                throw new Exception("MaxLevel must be greater than zero.");
            }

        }

        public BigInteger CalculateMoneyForLevelUp()
        {
            return (BigInteger.Pow(9, Convert.ToInt32(Mathf.Pow(CurrentLevel, 2f)) + 11));
        }

        private bool CheckNeedMoney()
        {
            return (StatsSystem.Instance.GetMoney() >= CalculateMoneyForLevelUp());
        }

        public void LevelUp()
        {
            if (CurrentLevel < MaxLevel && CheckNeedMoney())
            {
                StatsSystem.Instance.UseMoney(CalculateMoneyForLevelUp());
                CurrentLevel++;
                OnSpaceshipsLevelUp?.Invoke();
            }
        }

        public Sprite FindAppropriateSprite()
        {
            return _spaceshipsLevelSprites.GetCurrentSprite(_currentLevel);
        }
    }
}