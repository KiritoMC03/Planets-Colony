using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;

namespace PlanetsColony
{
    public class Cargo : Resource
    {
        public Cargo(Type type, uint value) : base(type, value)
        {
            this.value = value;
            this._type = type;
        }

        public Cargo(Type type, uint minValue, uint maxValue) : base(type, minValue, maxValue)
        {
            this.value = (uint)Random.Range(minValue, maxValue);
            this._type = type;
        }

        public override float GetPrice()
        {
            return 0f;
        }

        public override ulong GetValue()
        {
            return value;
        }

        public override Resource.Type GetResourceType()
        {
            return _type;
        }
    }
}