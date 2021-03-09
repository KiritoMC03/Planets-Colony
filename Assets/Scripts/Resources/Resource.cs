
using UnityEngine;

namespace PlanetsColony
{
    public class Resource
    {
        protected float value { get; set; }
        protected Type _type;

        public Resource(Type type, float value)
        {
            this.value = value;
            this._type = type;
        }
        public Resource(Type type, float minValue, float maxValue)
        {
            this.value = Random.Range(minValue, maxValue);
            this._type = type;
        }

        public enum Type
        {
            Iron,
            Gold,
            Silver
        }

        public virtual float GetPrice()
        {
            return 0f;
        }

        public virtual float GetValue()
        {
            return value;
        }

        public virtual Resource.Type GetResourceType()
        {
            return _type;
        }

        public virtual void Add(float value)
        {
            this.value += value;
        }
    }
}