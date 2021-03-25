using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony
{
    public class ResourcesStorage : MonoBehaviour
    {
        public UnityEvent ResourceChange;

        [SerializeField]
        private Resource[] resources = new Resource[]
        {
            new Resource(Resource.Type.Iron, 0),
            new Resource(Resource.Type.Gold, 0),
            new Resource(Resource.Type.Silver, 0),
            new Resource(Resource.Type.Uran, 0),
            new Resource(Resource.Type.Titan, 0)
        };

        public void AcceptCargoFromShip(Cargo cargo)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if (cargo.GetResourceType() == resources[i].GetResourceType())
                {
                    resources[i].Add(cargo.GetValue());
                    ResourceChange?.Invoke();
                }
            }
        }

        public ulong GetResourceValue(Resource.Type type)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if(resources[i].GetResourceType() == type)
                {
                    return resources[i].GetValue();
                }
            }

            return 0;
        }

        public ulong GetResourceToTrade(Resource.Type type, ulong value)
        {
            ulong returnValue = 0;
            for (int i = 0; i < resources.Length; i++)
            {
                if (resources[i].GetResourceType() == type)
                {
                    returnValue = resources[i].GetValue();
                    resources[i].SubstractValue(value);
                    ResourceChange?.Invoke();
                }
            }
            return returnValue;
        }
    }
}