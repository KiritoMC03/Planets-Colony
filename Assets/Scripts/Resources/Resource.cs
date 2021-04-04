using System;
using UnityEngine;

namespace PlanetsColony.Resources
{
    public class Resource
    {
        protected ulong value { get; set; }
        protected Type _type;
        // 0 - абсолютно не нужен, 255 - абсолютно нужен
        protected byte _marketValue = 10;
        protected ulong _soldValue = 0;
        private static Array _typeValue = Enum.GetValues(typeof(Type));
        private string minMaxValueErrorText = $"Аргументы minValue и maxValue должны быть в пределаха от {ulong.MinValue} до {ulong.MaxValue}";
        private static int[] _typesArray = (int[])(Enum.GetValues(typeof(Type)));

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

        public enum Type : uint
        {
            Aluminum,
			Ammonia,
			Asbestos,
			Calcium,
			Chromium,
			Copper,
			Diamonds,
			Gold,
			Graphite,
			Helium3,
			Hydrargyrum,
			Hydrogen,
			Iron,
			Lead,
			Manganese,
			Molybdenum,
			Nickel,
			Nitrogen,
			Phosphorus,
			Potassium,
			Silicon,
			Silver,
			Sulfur,
			Tin,
			Titan,
			Tungsten,
			Uran,
			Zinc
        }

        public virtual float GetPrice()
        {
            return 0f;
        }

        public virtual ulong GetValue()
        {
            return value;
        }

        public static int[] GetTypesArray()
        {
            return _typesArray;
        }

        public static Type GetType(int index)
        {
            return (Type)Enum.GetValues(typeof(Type)).GetValue(index);
        }

        public static int GetTypesCount()
        {
            return _typesArray.Length;
        }

        internal virtual void Sell(ulong value)
        {
            if(value <= this.value)
            {
                SubstractValue(value);
                _soldValue += value;
                StatsSystem.Instance.IncreaseAllResourceSoldValue(value);
            }
        }

        protected virtual void SubstractValue(ulong value)
        {
            this.value -= value;
        }

        public byte GetMarketValue()
        {
            return _marketValue;
        }

        internal void SetMarketValue(byte value)
        {
            this._marketValue = value;
        }

        public virtual Resource.Type GetResourceType()
        {
            return _type;
        }

        public virtual void Add(ulong value)
        {
            this.value += value;
        }

        public ulong GetSoldValue()
        {
            return _soldValue;
        }
    }
}