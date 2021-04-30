using PlanetsColony.Improvements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace PlanetsColony.Utils
{
    public class MultiplierCalculator : MonoBehaviour
    {
        public static BigInteger CalculateGeneratedResourceMultiplier(uint level)
        {
            return level;
        }

        public static BigInteger CalculateGeneratedResourceMultiplier(int level)
        {
            return level;
        }

        public static float CalculateCameraSpeedMultiplier(float speed, float distanceToSun)
        {
            return speed * Mathf.Sqrt(distanceToSun) / 5;
        }

        public static float CalculateOrbitLineWidthMultiplier(float distanceToSun, float baseWidth, float lineScale, float normalRenderDistance)
        {
            return distanceToSun * baseWidth * lineScale / normalRenderDistance;
        }
    }
}