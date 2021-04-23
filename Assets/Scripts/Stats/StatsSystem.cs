using PlanetsColony.Trading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PlanetsColony
{
    public class StatsSystem : MonoBehaviour
    {
        public UnityEvent OnMoneyValueChange;
        public UnityEvent OnShipCountChange;

        public static StatsSystem Instance = null;

        [SerializeField] private Earning _moneyGain = null;
        [SerializeField] private BigInteger _money = 0;
        [SerializeField] private uint _maxShipsCount = 10;
        [SerializeField] private uint _activeShipsCount = 0;

        private void Awake()
        {
            Instance = this;
			Application.targetFrameRate = 600;

            if (_moneyGain == null)
            {
                throw new NullReferenceException("Money Gain field must not be null.");
            }
        }

        private void Start()
        {
            if (SaveLoadSystem.Instance == null)
            {
                throw new NullReferenceException("Не найдено ни одного объекта с компоненом SaveLoadSystem.");
            }
            else
            {
                _money = SaveLoadSystem.Instance.LoadMoney();
            }
        }

        #region MoneyWork
        internal void AddMoney(BigInteger value)
        {
            Debug.Log("value: " + value);
            _moneyGain.Show(value);
            _money += value;
            OnMoneyValueChange?.Invoke();
        }

        internal void UseMoney(BigInteger value)
        {
            if (value > _money)
            {
                throw new Exception("Аргумент value превосходит число монет.");
            }
            else
            {
                _money -= value;
            }
            OnMoneyValueChange?.Invoke();
        }

        internal void TryUseMoney(ulong value)
        {
            if (value <= _money)
            {
                _money -= value;
            }
            OnMoneyValueChange?.Invoke();
        }
        #endregion

#region GettersSetters
        public uint GetMaxShipsCount()
        {
            return _maxShipsCount;
        }

        public uint GetActiveShipsCount()
        {
            return _activeShipsCount;
        }

        public BigInteger GetMoney()
        {
            return _money;
        }

        internal void SetMoney(BigInteger value)
        {
            _money = value;
        }

#endregion

#region ShipCountWork
        public void IncreaseActiveShipsCount()
        {
            if (_activeShipsCount < _maxShipsCount)
            {
                _activeShipsCount++;
                OnShipCountChange?.Invoke();
            }
        }

        public void ReduceActiveShipsCount()
        {
            if (_activeShipsCount > 0)
            {
                _activeShipsCount--;
                OnShipCountChange?.Invoke();
            }
        }
#endregion

#region Utils
        public bool CheckAbilityToSpawn()
        {
            return (_activeShipsCount < _maxShipsCount);
        }
#endregion
    }
}