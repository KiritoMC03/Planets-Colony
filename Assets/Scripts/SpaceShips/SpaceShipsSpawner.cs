using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony
{
    public class SpaceshipsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnFrom = null;
        [SerializeField] private Spaceship ship = null;
        [SerializeField] private uint count = 10;
        [Range(0.01f, 100f)]
        [SerializeField] private float delay = 1f;

        [SerializeField] private Transform target = null;
        [SerializeField] private Transform departureObject = null;

        private void Awake()
        {
            if(_spawnFrom == target)
            {
                throw new Exception("Spawn From не должен совпадать с Target.");
            }
            if(departureObject == null)
            {
                throw new Exception("Departure Object не должен быть пустым.");
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnerRoutine());
        }

        private IEnumerator SpawnerRoutine()
        {
            for (int i = 0; i < count; i++)
            {
                if (ship != null)
                {
                    Spaceship newShip = null;
                    if (_spawnFrom != null)
                    {
                        newShip = ObjectPooler.Instance.GetObject(ship.Type).GetComponent<Spaceship>();
                        newShip.transform.position = _spawnFrom.position;
                    }
                    else
                    {
                        newShip = Instantiate(ship);
                    }
                    newShip.SetTarget(target);
                    newShip.SetDepartureObject(departureObject);
                }
                yield return new WaitForSeconds(delay);
            }
        }
    }
}