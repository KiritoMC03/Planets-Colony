using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class StatsSystem : MonoBehaviour
    {
        public UnityEvent OnMoneyValueChange;
        public UnityEvent OnShipCountChange;

        public static StatsSystem Instance = null;

        [SerializeField] private ulong _money = 0;
        [SerializeField] private uint _maxShipsCount = 10;
        [SerializeField] private uint _activeShipsCount = 0;

        private void Awake()
        {
            Instance = this;
			Application.targetFrameRate = 60;
        }

        internal void AddMoney(ulong value)
        {
            _money += value;
            OnMoneyValueChange?.Invoke();
        }

        public ulong GetMoney()
        {
            return _money;
        }

        internal void UseMoney(ulong value)
        {
            if(value > this._money)
            {
                throw new Exception("Аргумент value превосходит число монет.");
            }
            else
            {
                this._money -= value;
            }
            OnMoneyValueChange?.Invoke();
        }

        internal void TryUseMoney(ulong value)
        {
            if (value <= this._money)
            {
                this._money -= value;
            }
            OnMoneyValueChange?.Invoke();
        }

        public uint GetMaxShipsCount()
        {
            return _maxShipsCount;
        }
        public uint GetActiveShipsCount()
        {
            return _activeShipsCount;
        }

        public bool CheckAbilityToSpawn()
        {
            return (_activeShipsCount < _maxShipsCount);
        }

        public void IncreaseActiveShipsCount()
        {
            if(_activeShipsCount < _maxShipsCount)
            {
                _activeShipsCount++;
                OnShipCountChange?.Invoke();
            }
        }

        public void ReduceActiveShipsCount()
        {
            if(_activeShipsCount > 0)
            {
                _activeShipsCount--;
                OnShipCountChange?.Invoke();
            }
        }
    }
}