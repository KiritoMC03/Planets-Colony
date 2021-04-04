using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;


namespace PlanetsColony
{
    public class TradingSystem : MonoBehaviour
    {
        [SerializeField] internal static TradingSystem Instance = null;

        private Resource[] _resources = null;

        private void Awake()
        {
            Instance = this;
        }
    }
}