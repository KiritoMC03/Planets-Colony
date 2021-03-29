using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace PlanetsColony
{
    public static class Converter
    {
        private static Pow[] powsList = new Pow[]
        {
            new Pow("млн.", 6),
            new Pow("млрд.", 9),
            new Pow("трл.", 12),
            new Pow("квдр.", 15),
            new Pow("квнт.", 15)
        };

        public static string ValueToString(uint value)
        {
            for (int i = 0; i < powsList.Length; i++)
            {
                if (value < powsList[i].GetValue())
                {
                    return value.ToString();
                }

                if (value / powsList[i].GetValue() < 1000)
                {
                    return Math.Round((value / powsList[i].GetValue()), 2) + powsList[i].GetName();
                }
            }

            return value.ToString();
        }

        public static string ValueToString(ulong value)
        {
            for (int i = 0; i < powsList.Length; i++)
            {
                if (value < powsList[i].GetValue())
                {
                    return value.ToString();
                }

                if (value / powsList[i].GetValue() < 1000)
                {
                    return Math.Round((value / powsList[i].GetValue()), 2) + powsList[i].GetName();
                }
            }

            return value.ToString();
        }

        public static string ValueToString(BigInteger value)
        {
            for (int i = 0; i < powsList.Length; i++)
            {
                if (value < (BigInteger)powsList[i].GetValue())
                {
                    return value.ToString();
                }

                if (value / (BigInteger)powsList[i].GetValue() < 1000)
                {
                    return value / (BigInteger)powsList[i].GetValue() + powsList[i].GetName();
                }
            }

            return value.ToString();
        }
    }


    public class Pow
    {
        private string _name;
        private double _value;
        private uint _digits;

        public Pow(string name, uint digits)
        {
            this._name = name;
            this._digits = digits;

            this._value = Math.Pow(10, digits);
        }
        public string GetName()
        {
            return _name;
        }

        public double GetValue()
        {
            return _value;
        }

        public uint GetDigits()
        {
            return _digits;
        }
    }
}