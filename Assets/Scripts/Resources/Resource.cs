
using UnityEngine;

namespace PlanetsColony
{
    public class Resource
    {
        protected uint value { get; set; }
        protected Type _type;

        public Resource(Type type, uint value)
        {
            this.value = value;
            this._type = type;
        }
        public Resource(Type type, uint minValue, uint maxValue)
        {
            this.value = (uint)Random.Range(minValue, maxValue);
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

        public virtual uint GetValue()
        {
            return value;
        }

        internal virtual void SubstractValue(uint value)
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

        public virtual void Add(uint value)
        {
            this.value += value;
        }
    }
}