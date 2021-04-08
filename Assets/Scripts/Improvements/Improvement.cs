using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony.Improvements
{
    public abstract class Improvement : MonoBehaviour
    {
        protected int _level;

        public abstract string GetLabel();

        public virtual int GetLevel()
        {
            return _level;
        }

        public virtual bool LevelUp()
        {
            return false;
        }
    }
}
