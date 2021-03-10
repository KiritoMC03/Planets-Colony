using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class ResourcesStorage : MonoBehaviour
    {
        public UnityEvent ResourceAdd;

        [SerializeField]
        private Resource[] resources = new Resource[]
        {
            new Resource(Resource.Type.Iron, 0),
            new Resource(Resource.Type.Gold, 0),
            new Resource(Resource.Type.Silver, 0),
        };

        public void AcceptCargoFromShip(Cargo cargo)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if (cargo.GetResourceType() == resources[i].GetResourceType())
                {
                    resources[i].Add(cargo.GetValue());
                    ResourceAdd?.Invoke();
                }
            }
        }

        public float GetResourceValue(Resource.Type type)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if(resources[i].GetResourceType() == type)
                {
                    return Mathf.Floor(resources[i].GetValue());
                }
            }

            return 0f;
        }
    }
}