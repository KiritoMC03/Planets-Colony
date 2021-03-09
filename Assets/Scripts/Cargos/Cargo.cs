using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony
{
    public class Cargo : Resource, ICargo
    {
        public Cargo(Type type, float value) : base(type, value)
        {
            this.value = value;
            this._type = type;
        }

        public Cargo(Type type, float minValue, float maxValue) : base(type, minValue, maxValue)
        {
            this.value = Random.Range(minValue, maxValue);
            this._type = type;
        }

        public override float GetPrice()
        {
            return 0f;
        }

        public override float GetValue()
        {
            return value;
        }

        public override Resource.Type GetResourceType()
        {
            return _type;
        }
    }
}