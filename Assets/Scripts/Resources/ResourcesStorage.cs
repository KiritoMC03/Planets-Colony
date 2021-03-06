using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class ResourcesStorage : MonoBehaviour, IAcceptShipWithCargo
    {
        [SerializeField]
        private Resource[] resources = new Resource[]
        {
            new Resource(Resource.Type.Iron, 0),
            new Resource(Resource.Type.Gold, 0),
            new Resource(Resource.Type.Silver, 0),
        };

        public void AcceptCargoFromShip(ICargo cargo)
        {
            for (int i = 0; i < resources.Length; i++)
            {
                if (cargo.GetResourceType() == resources[i].GetResourceType())
                {
                    resources[i].Add(cargo.GetValue());

                    Debug.Log("Type: " + cargo.GetResourceType() + " ||| Value: " + cargo.GetValue());
                    Debug.Log("Type: " + cargo.GetResourceType() + " ||| AllValue: " + resources[i].GetValue());
                }
            }
        }
    }
}