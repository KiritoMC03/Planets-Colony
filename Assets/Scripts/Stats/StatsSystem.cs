using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class StatsSystem : MonoBehaviour
    {
        public UnityEvent ShipCountChange;

        public static StatsSystem Instance = null;

        [SerializeField] private ulong _money = 0;
        [SerializeField] private uint _maxShipsCount = 10;
        [SerializeField] private uint _activeShipsCount = 0;
        [SerializeField] private uint _score = 0;

        private void Awake()
        {
            Instance = this;
			Application.targetFrameRate = 60;
        }

        internal void AddMoney(ulong value)
        {
            _money += value;
        }

        public ulong GetMoney()
        {
            return _money;
        }

        public uint GetScore()
        {
            return _score;
        }
        public void UseScore()
        {
            if(_score > 0)
            {
                _score--;
            }
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
                ShipCountChange?.Invoke();
            }
        }

        public void ReduceActiveShipsCount()
        {
            if(_activeShipsCount > 0)
            {
                _activeShipsCount--;
                ShipCountChange?.Invoke();
            }
        }
    }
}