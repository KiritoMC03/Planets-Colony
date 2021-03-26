using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class BuilderSpaceship : Spaceship
    {
        [SerializeField] private float _factoryBuildTime = 3f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = GetTarget();
            var tempFactory = collision.GetComponent<Factory>();

            if (collision.transform == tempTarget && tempFactory != null)
            {
                tempFactory.Build(_factoryBuildTime);
                ObjectPooler.Instance.DestroyObject(gameObject);
            }
        }
    }
}
