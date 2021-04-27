using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Pirates
{
    public class PiratesSpawner : MonoBehaviour
    {

        [Header("Implements IPirate.")]
        [SerializeField] private GameObject _piratePrefab = null;
        [SerializeField] private int _spawnCount = 10;
        [SerializeField] private float _spawnDelay = 0.5f;
        [SerializeField] private float _spawnBanRadius = 10f;
        [SerializeField] private float _maxSpawnRadius = 100f;
        [Header("Implements IPirateGuide.")]
        [SerializeField] private GameObject _pirateGuide = null;
        [SerializeField] private Transform _centralSun = null;
        
        private IPirate _pirate = null;
        private IPirateGuide _guide = null;

        private void Awake()
        {
            _pirate = _piratePrefab.GetComponent<IPirate>();
            _guide = _pirateGuide.GetComponent<IPirateGuide>();
            if (_pirate == null)
            {
                throw new NullReferenceException("Pirate Prefab field ERROR. No component that implements the IPirate interface was found.");
            }
            if (_guide == null)
            {
                throw new NullReferenceException("Pirate Guide field ERROR. No component that implements the IPirateGuide interface was found.");
            }

            if (_centralSun == null)
            {
                throw new Exception("Central Sun field must not be null.");
            }
        }

        private void Start()
        {
            /*
            for (int i = 0; i < _spawnCount; i++)
            {
                var spawnPosition = FindSpawnPosition(_centralSun, _spawnBanRadius, _maxSpawnRadius);
                var target = _guide.GetRandomTarget().transform;
                Spawn(spawnPosition, target);
            }
            */
            StartCoroutine(SpawnerRoutine(_spawnDelay));
        }

        public void Spawn(Vector3 spawnPosition, Transform target)
        {
            var pirate = ObjectPooler.Instance.GetObject(ObjectPooler.ObjectInfo.ObjectType.Pirate);
            pirate.transform.position = spawnPosition;
            var pirateComponent = pirate.GetComponent<IPirate>();
            pirateComponent.SetTarget(target);
            pirateComponent.SetSpawnPosition(spawnPosition);
        }

        private Vector2 FindSpawnPosition(Transform centre, float minSpawnRadius, float maxSpawnRadius)
        {
            var centrePosition = (Vector2)centre.transform.position;
            var angle = UnityEngine.Random.Range(-4f, 4f);
            var offset = UnityEngine.Random.Range(minSpawnRadius, maxSpawnRadius);
            var position = centrePosition + new Vector2(Mathf.Sin(angle) * offset, Mathf.Cos(angle) * offset);

            return position;
        }

        private IEnumerator SpawnerRoutine(float delay)
        {
            while (true)
            {
                var spawnPosition = FindSpawnPosition(_centralSun, _spawnBanRadius, _maxSpawnRadius);
                var target = _guide.GetRandomTarget().transform;
                Spawn(spawnPosition, target);

                yield return new WaitForSeconds(delay);
            }
        }
    }
}