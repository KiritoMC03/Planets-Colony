using UnityEngine;
using PlanetsColony.Factories;

namespace PlanetsColony.Spaceships.Types
{
    public class BuilderSpaceship : Spaceship
    {
        [SerializeField] private float _factoryBuildTime = 3f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var tempTarget = GetTarget();
            var tempFactoryBuilder = collision.GetComponent<IFactoryBuilder>();
            var tempFactory = collision.GetComponent<Factory>();

            if (collision.transform == tempTarget && tempFactory != null)
            {
                tempFactoryBuilder.Build(tempFactory, _factoryBuildTime);
                ObjectPooler.Instance.DestroyObject(gameObject);
            }
        }
    }
}
