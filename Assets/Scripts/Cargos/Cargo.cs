using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class Cargo : ICargo
    {
        [SerializeField] private float value = 0f;

        public Cargo(float minValue, float maxValue)
        {
            value = Random.Range(minValue, maxValue);
        }

        public float GetPrice()
        {
            return 0f;
        }

        public float GetValue()
        {
            return value;
        }
    }
}