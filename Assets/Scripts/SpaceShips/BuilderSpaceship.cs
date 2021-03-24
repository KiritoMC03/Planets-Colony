using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class BuilderSpaceship : Spaceship
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = GetTarget();

            if (collision.transform == tempTarget)
            {
                ObjectPooler.Instance.DestroyObject(gameObject);
            }
        }
    }
}
