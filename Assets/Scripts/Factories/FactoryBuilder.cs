using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Factories
{
    public class FactoryBuilder : MonoBehaviour, IFactoryBuilder
    {
        public void Build(Factory factory, float delay)
        {
            StartCoroutine(FactoryBuildRoutine(factory, delay));
        }

        private IEnumerator FactoryBuildRoutine(Factory factory, float delay)
        {
            yield return new WaitForSeconds(delay);
            factory.GetLinkToIFactoryLevel().SetLevel(1);
            factory.Activate();
        }
    }
}