using PlanetsColony.Cargos;
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

        private Dictionary<Resource.Type, BigInteger> _resources = new Dictionary<Resource.Type, BigInteger>();
        private void Awake()
        {
            _resources = Resource.GenerateDictionaryByTypes<BigInteger>(0);
        }

        public void AcceptCargoFromShip(List<Cargo> cargos)
        {
            for (int i = 0; i < cargos.Count; i++)
            {
                var thisCargo = cargos[i];
                _resources[thisCargo.GetResourceType()] += thisCargo.GetValue();
                ResourceChange?.Invoke();

                BigInteger.Add(_resources[thisCargo.GetResourceType()], thisCargo.GetValue());
            }
        }

#region GettersSetters
        public BigInteger GetResourceValue(Resource.Type type)
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

        public BigInteger GetResourceToTrade(Resource.Type type, BigInteger value)
        {
            BigInteger returnValue = 0;
            if (value <= _resources[type])
            {
                returnValue = value;
                _resources[type] -= returnValue;
                ResourceChange?.Invoke();
                ResourceSalesAccount.AddSoldValue(type, value);
                ResourceSalesAccount.AddAllResourceSoldValue(value);
            }
            return returnValue;
        }
        public ref Dictionary<Resource.Type, BigInteger> GetInitResourcesRef()
        {
            return ref _resources;
        }
#endregion
    }
}