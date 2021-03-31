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
            new Pow(" тыс.", 3),
            new Pow(" млн.", 6),
            new Pow(" млрд.", 9),
            new Pow(" трлн.", 12),
            new Pow(" квадрлн.", 15),
            new Pow(" квинтлн.", 18),
            new Pow(" cекстлн.", 21),
            new Pow(" септлн.", 24),
            new Pow(" октлн.", 27),
            new Pow(" нонлн.", 30),
            new Pow(" децлн.", 33),
            new Pow(" ундецлн.", 36),
            new Pow(" дуодецлн.", 39),
            new Pow(" тредецлн.", 42),
            new Pow(" кваттуордецлн.", 45),
            new Pow(" квиндецлн.", 48),
            new Pow(" сексдецлн.", 51),
            new Pow(" септдецлн.", 54),
            new Pow(" октдецлн.", 57),
            new Pow(" новемдецлн.", 60)
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