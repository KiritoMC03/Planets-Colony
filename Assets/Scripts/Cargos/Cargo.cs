using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;
using PlanetsColony.Trading;
using System.Numerics;

namespace PlanetsColony
{
    public class Cargo : Resource
    {
        private BigInteger _value { get; set; }

        public Cargo(Type type, BigInteger value)
        {
            this._value = value;
            this._type = type;
        }

        public Cargo(Type type, ulong minValue, ulong maxValue)
        {
            this._value = (ulong)Random.Range(minValue, maxValue);
            this._type = type;
        }

        public Cargo(Type type, ulong minValue, ulong maxValue, BigInteger multiplier)
        {
            this._value = multiplier * (ulong)Random.Range(minValue, maxValue);
            this._type = type;
        }

        public BigInteger GetValue()
        {
            return _value;
        }

        public override Resource.Type GetResourceType()
        {
            return _type;
        }
    }
}