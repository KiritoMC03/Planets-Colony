using PlanetsColony.Trading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

namespace PlanetsColony.Resources
{
    public class ResourcesStorage : MonoBehaviour
    {
        public UnityEvent ResourceChange;

        private Dictionary<Resource.Type, ulong> _resources = new Dictionary<Resource.Type, ulong>();
        
        /*
        [SerializeField]
        private Resource[] resources = new Resource[]
        {
            new Resource(Resource.Type.Aluminum, 0),
			new Resource(Resource.Type.Ammonia, 0),
			new Resource(Resource.Type.Asbestos, 0),
			new Resource(Resource.Type.Calcium, 0),
			new Resource(Resource.Type.Chromium, 0),
			new Resource(Resource.Type.Copper, 0),
			new Resource(Resource.Type.Diamonds, 0),
			new Resource(Resource.Type.Gold, 0),
			new Resource(Resource.Type.Graphite, 0),
			new Resource(Resource.Type.Helium3, 0),
			new Resource(Resource.Type.Hydrargyrum, 0),
			new Resource(Resource.Type.Hydrogen, 0),
			new Resource(Resource.Type.Iron, 0),
			new Resource(Resource.Type.Lead, 0),
			new Resource(Resource.Type.Manganese, 0),
			new Resource(Resource.Type.Molybdenum, 0),
			new Resource(Resource.Type.Nitrogen, 0),
			new Resource(Resource.Type.Nickel, 0),
			new Resource(Resource.Type.Phosphorus, 0),
			new Resource(Resource.Type.Potassium, 0),
			new Resource(Resource.Type.Silicon, 0),
			new Resource(Resource.Type.Silver, 0),
			new Resource(Resource.Type.Sulfur, 0),
			new Resource(Resource.Type.Tin, 0),
			new Resource(Resource.Type.Titan, 0),
			new Resource(Resource.Type.Tungsten, 0),
			new Resource(Resource.Type.Uran, 0),
			new Resource(Resource.Type.Zinc, 0)
        };
        */

        private void Awake()
        {
            _resources = Resource.GenerateDictionaryByTypes<ulong>(0);
        }

        public void AcceptCargoFromShip(List<Cargo> cargos)
        {
            for (int i = 0; i < cargos.Count; i++)
            {
                var thisCargo = cargos[i];
                _resources[thisCargo.GetResourceType()] += thisCargo.GetValue();
                ResourceChange?.Invoke();

                //BigInteger.Add(_resources[thisCargo.GetResourceType()], thisCargo.GetValue());
            }
        }

        public ulong GetResourceValue(Resource.Type type)
        {
            try
            {
                return _resources[type];
            }  
            catch
            {
                throw new Exception($"ResourceType {nameof(type)} don`t found.");
            }
        }

        public ulong GetResourceToTrade(Resource.Type type, ulong value)
        {
            ulong returnValue = 0;
            if(value <= _resources[type])
            {
                returnValue = value;
                _resources[type] -= returnValue;
                ResourceChange?.Invoke();
            }
            return returnValue;
        }

        public ref Dictionary<Resource.Type, ulong> GetInitResourcesRef()
        {
            return ref _resources;
        }
    }
}