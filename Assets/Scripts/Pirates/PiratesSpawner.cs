using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    public class PiratesSpawner : MonoBehaviour
    {
        [SerializeField] private Pirate _pirate = null;
        [SerializeField] private float _spawnBanRadius = 10f;
        [SerializeField] private float _maxSpawnRadius = 100f;
        [SerializeField] private Transform _centralSun = null;

        private void Awake()
        {
            if (_pirate == null)
            {
                throw new Exception("Pirate field must not be null.");
            }
            if (_centralSun == null)
            {
                throw new Exception("Central Sun field must not be null.");
            }
        }

        private void Start()
        {
            for (int i = 0; i < 5000; i++)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            Instantiate(_pirate, FindSpawnPosition(_centralSun, _spawnBanRadius, _maxSpawnRadius), Quaternion.identity);
        }

        private Vector2 FindSpawnPosition(Transform centre, float minSpawnRadius, float maxSpawnRadius)
        {
            var centrePosition = (Vector2)centre.transform.position;
            var angle = UnityEngine.Random.Range(-4f, 4f);
            var offset = UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius);
            var position = centrePosition + new Vector2(Mathf.Sin(angle) * offset, Mathf.Cos(angle) * offset);

            return position;
        }
    }
}