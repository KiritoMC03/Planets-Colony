using PlanetsColony.Trading;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Resources
{
    public class Resource
    {
        protected Type _type;
        private string _minMaxValueErrorText = $"Аргументы minValue и maxValue должны быть в пределаха от {ulong.MinValue} до {ulong.MaxValue}";
        private static int[] _typesArray = (int[])(Enum.GetValues(typeof(Type)));

        /*
        public Resource(Type type, ulong value)
        {
            this.value = value;
            this._type = type;
        }
        public Resource(Type type, ulong minValue, ulong maxValue)
        {
            if(minValue < ulong.MinValue || maxValue > ulong.MaxValue)
            {
                throw new Exception(_minMaxValueErrorText);
            }
            this.value = (ulong)UnityEngine.Random.Range(minValue, maxValue);
            this._type = type;
        }
        */
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

        public static Dictionary<Type, TValue> GenerateDictionaryByTypes<TValue>(TValue value)
        {
            Dictionary<Type, TValue> dictionary = new Dictionary<Type, TValue>();
            for (int i = 0; i < GetTypesCount(); i++)
            {
                dictionary.Add(GetType(i), value);
                dictionary[GetType(i)] = value;
            }
            return dictionary;
        }

#region GettersSetters
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
        public virtual Type GetResourceType()
        {
            return _type;
        }
#endregion
    }
}