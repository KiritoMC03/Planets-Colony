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

#region GettersSetters
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
            if (value <= _resources[type])
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
#endregion
    }
}