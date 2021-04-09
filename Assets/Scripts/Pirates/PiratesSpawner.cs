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

        private Vector2 FindSpawnPosition(Transform centre, float spawnBanRadius, float maxSpawnRadius)
        {
            var f = (Vector2)centre.transform.position + ((maxSpawnRadius - spawnBanRadius) * UnityEngine.Random.insideUnitCircle);

            /*
            var x = Mathf.Cos(UnityEngine.Random.Range(0, 1)) * UnityEngine.Random.Range(spawnBanRadius, maxSpawnRadius);
            var y = Mathf.Cos(UnityEngine.Random.Range(0, 1)) * UnityEngine.Random.Range(spawnBanRadius, maxSpawnRadius);
            SetAxisOffset(ref x, centre.position.x, spawnBanRadius);
            SetAxisOffset(ref y, centre.position.y, spawnBanRadius);
            */
            f = SetRange(f, spawnBanRadius);
            return f; //new Vector2(x, y);
        }

        private Vector2 SetRange(Vector2 position, float spawnBanRadius)
        {
            if (position.x > 0)
            {
                position.x += spawnBanRadius;
            }
            else
            {
                position.x -= spawnBanRadius;
            }

            if (position.y > 0)
            {
                position.y += spawnBanRadius;
            }
            else
            {
                position.y -= spawnBanRadius;
            }

            return position;
        }

        private void SetAxisOffset(ref float axis, float centreAxis, float spawnBanRadius)
        {
            if (axis > 0)
            {
                axis += /*spawnBanRadius*/ + centreAxis;
            }
            else
            {
                axis += /*-spawnBanRadius*/ + centreAxis;
            }
        }
    }
}