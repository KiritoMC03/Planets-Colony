using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    [Serializable]
    public class PirateGuide : MonoBehaviour, IPirateGuide
    {
        [SerializeField] private Planet[] _targetPlanets = null;
        private Transform[] _targetPlanetsTransform = null;

        private void Awake()
        {
            if (_targetPlanets == null || _targetPlanets.Length < 0)
            {
                throw new Exception("TargetPlanets is null.");
            }

            _targetPlanetsTransform = new Transform[_targetPlanets.Length];
            for (int i = 0; i < _targetPlanets.Length; i++)
            {
                _targetPlanetsTransform[i] = _targetPlanets[i].transform;
            }
        }

        public Planet GetRandomTarget()
        {
            var random = UnityEngine.Random.Range(0, _targetPlanets.Length - 1);
            return _targetPlanets[random];
        }

        public Planet TryGetRandomTarget()
        {
            try
            {
                var random = UnityEngine.Random.Range(0, _targetPlanets.Length - 1);
                return _targetPlanets[random];
            }
            catch (Exception)
            {
                return _targetPlanets[0];
            }
        }
    }
}
