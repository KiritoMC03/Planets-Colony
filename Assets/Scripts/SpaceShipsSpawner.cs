using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony
{
    public class SpaceShipsSpawner : MonoBehaviour
    {
        [SerializeField] private SpaceShip ship = null;
        [SerializeField] private uint count = 10;
        [Range(0.01f, 100f)]
        [SerializeField] private float delay = 1f;

        [SerializeField] private Transform target = null;

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
                    var newShip = Instantiate(ship);
                    newShip.SetTarget(target);
                }
                yield return new WaitForSeconds(delay);
            }
        }
    }
}