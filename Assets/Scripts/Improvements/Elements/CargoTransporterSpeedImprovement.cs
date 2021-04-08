using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony.Improvements
{
    public class CargoTransporterSpeedImprovement : MonoBehaviour, IImprovement
    {
        public UnityEvent OnLevelUp;

        internal static CargoTransporterSpeedImprovement Instance = null;
        private static int _level = 1;
        private static string _label = "Скорость грузоперевозчиков: ";

        private void Awake()
        {
            Instance = this;
        }

        public static float GetImprovedSpeed(float speed)
        {
            if (_level < 1)
            {
                throw new Exception("_level cannot be less than one.");
            }
            return speed * (float)Math.Sqrt(_level) * Time.deltaTime / 5f;
        }

        public string GetLabel()
        {
            return _label;
        }

        public int GetLevel()
        {
            return _level;
        }

        public void LevelUp()
        {
            _level++;
            OnLevelUp?.Invoke();
        }
    }
}
