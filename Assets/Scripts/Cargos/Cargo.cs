using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanetsColony.Resources;
using PlanetsColony.Trading;
using System.Numerics;

namespace PlanetsColony.Cargos
{
    public class Cargo : Resource
    {
        private BigInteger _value { get; set; }

        public Cargo(Type type, BigInteger value)
        {
            this._value = value;
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