using System;
using UnityEngine;

namespace PlanetsColony
{
    public class Resource
    {
        protected ulong value { get; set; }
        protected Type _type;
        private string minMaxValueErrorText = $"Аргументы minValue и maxValue должны быть в пределаха от {ulong.MinValue} до {ulong.MaxValue}";

        public Resource(Type type, ulong value)
        {
            this.value = value;
            this._type = type;
        }
        public Resource(Type type, ulong minValue, ulong maxValue)
        {
            if(minValue < ulong.MinValue || maxValue > ulong.MaxValue)
            {
                throw new Exception(minMaxValueErrorText);
            }
            this.value = (ulong)UnityEngine.Random.Range(minValue, maxValue);
            this._type = type;
        }

        public enum Type
        {
            Iron,
            Gold,
            Silver,
			Uran,
			Titan
        }

        public virtual float GetPrice()
        {
            return 0f;
        }

        public virtual ulong GetValue()
        {
            return value;
        }

        internal virtual void SubstractValue(ulong value)
        {
            if(value <= this.value)
            {
                this.value -= value;
            }
        }

        public virtual Resource.Type GetResourceType()
        {
            return _type;
        }

        public virtual void Add(ulong value)
        {
            this.value += value;
        }
    }
}