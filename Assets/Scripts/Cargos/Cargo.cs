using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;
using PlanetsColony.Trading;

namespace PlanetsColony
{
    public class Cargo : Resource
    {
        private ulong value { get; set; }

        public Cargo(Type type, uint value)
        {
            this.value = value;
            this._type = type;
        }

        public Cargo(Type type, uint minValue, uint maxValue)
        {
            this.value = (uint)Random.Range(minValue, maxValue);
            this._type = type;
        }

        public ulong GetValue()
        {
            return value;
        }

        public override Resource.Type GetResourceType()
        {
            return _type;
        }

        internal void Sell(ulong value)
        {
            if (value <= this.value)
            {
                SubstractValue(value);
                ResourceSalesAccount.AddSoldValue(_type, value);
                ResourceSalesAccount.AddAllResourceSoldValue(value);
            }
        }

        private void SubstractValue(ulong value)
        {
            this.value -= value;
        }

        public void Add(ulong value)
        {
            this.value += value;
        }
    }
}