using PlanetsColony.Trading;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetsColony.Resources
{
    public class Resource
    {
        protected Type _type;
        private static int[] _typesArray = (int[])Enum.GetValues(typeof(Type));

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
            for (int i = 0; i < GetPossibleTypesCount(); i++)
            {
                dictionary.Add(GetType(i), value);
                dictionary[GetType(i)] = value;
            }
            return dictionary;
        }

        public static int GetPossibleTypesCount()
        {
            return _typesArray.Length;
        }

        public virtual Type GetResourceType()
        {
            return _type;
        }

        public static Type GetType(int index)
        {
            return (Type)_typesArray.GetValue(index);
        }

        public static Type TryGetType(int index)
        {
            CheckPossibilityOfGetType(index);
            return (Type)_typesArray.GetValue(index);
        }

        private static void CheckPossibilityOfGetType(int index)
        {
            if (index > GetPossibleTypesCount())
            {
                throw new ArgumentOutOfRangeException("The index exceeds the number of resource types.");
            }
            else if (index < 0)
            {
                throw new ArgumentOutOfRangeException("The index cannot be negative.");
            }
        }
    }
}