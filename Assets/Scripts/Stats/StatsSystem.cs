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

        [SerializeField] private float _maxShipsCount = 10f;
        [SerializeField] private float _activeShipsCount = 0f;

        private void Awake()
        {
            Instance = this;
        }

        public float GetMaxShipsCount()
        {
            return _maxShipsCount;
        }
        public float GetActiveShipsCount()
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