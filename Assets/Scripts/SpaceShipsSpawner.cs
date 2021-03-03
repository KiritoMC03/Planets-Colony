using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony
{
    public class SpaceShipsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnFrom = null;
        [SerializeField] private SpaceShip ship = null;
        [SerializeField] private uint count = 10;
        [Range(0.01f, 100f)]
        [SerializeField] private float delay = 1f;

        [SerializeField] private Transform target = null;

        private void Awake()
        {
            if(_spawnFrom == target)
            {
                throw new Exception("Spawn From не должен совпадать с Target.");
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnerRoutine());
        }

        private IEnumerator SpawnerRoutine()
        {
            while (true)
            {
                if (ship != null)
                {
                    SpaceShip newShip = null;
                    if (_spawnFrom != null)
                    {
                        newShip = Instantiate(ship, _spawnFrom);
                    }
                    else
                    {
                        newShip = Instantiate(ship);
                    }
                    newShip.SetTarget(target);
                }
                yield return new WaitForSeconds(delay);
            }
        }
    }
}