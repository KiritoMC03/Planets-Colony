using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class SpaceshipsPort : MonoBehaviour
    {
        [SerializeField] private Spaceship ship = null;
        [SerializeField] private Transform[] planets = null;
        [Range(0.01f, 100f)]
        [SerializeField] private float delay = 1f;

        private Transform _transform = null;
        private Transform _departureObject = null;
        private Coroutine _spawnerRoutine = null;
        private Spaceship tempShip = null;

        private void Awake()
        {
            _transform = transform;
            _departureObject = _transform;

            for (int i = 0; i < planets.Length; i++)
            {
                if (_transform == planets[i])
                {
                    throw new Exception("В списке планет не может быть место отправки.");
                }
            }

            if (ship == null)
            {
                throw new Exception("Установите поле Ship.");
            }
        }

        private IEnumerator SpawnerRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                for (int i = 0; i < planets.Length; i++)
                {
                    if (StatsSystem.Instance.CheckAbilityToSpawn())
                    {
                        SendShip(planets[i]);
                        StatsSystem.Instance.IncreaseActiveShipsCount();
                    }
                }
            }
        }

        private void SendShip(Transform target)
        {
            tempShip = ObjectPooler.Instance.GetObject(ship.Type).GetComponent<Spaceship>();
            
            tempShip.transform.position = _transform.position;

            tempShip.SetTarget(target);
            tempShip.SetDepartureObject(_departureObject);
            
            tempShip = null;
        }

        private void OnEnable()
        {
            _spawnerRoutine = StartCoroutine(SpawnerRoutine());
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}