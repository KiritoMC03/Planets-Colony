using System;
using System.Collections.Generic;
using UnityEngine;

public static class Converter
{
    public static string ValueToString(uint value)
    {
        if (value > Math.Pow(10, 6))
        {
            return Math.Round(value / Math.Pow(10, 6), 2) + " млн.";
        }
        else if (value > Math.Pow(10, 9))
        {
            return Math.Round(value / Math.Pow(10, 9), 2) + " млрд.";
        }
        else if (value > Math.Pow(10, 12))
        {
            return Math.Round(value / Math.Pow(10, 12), 2) + " трл.";
        }
        else if (value > Math.Pow(10, 15))
        {
            return Math.Round(value / Math.Pow(10, 15), 2) + " квдр.";
        }
        else if (value > Math.Pow(10, 18))
        {
            return Math.Round(value / Math.Pow(10, 18), 2) + " квнт.";
        }
        else
        {
            return value + "";
        }
    }

    public static string ValueToString(ulong value)
    {
        if (value > Math.Pow(10, 6))
        {
            return Math.Round(value / Math.Pow(10, 6), 2) + " млн.";
        }
        else if (value > Math.Pow(10, 9))
        {
            return Math.Round(value / Math.Pow(10, 9), 2) + " млрд.";
        }
        else if (value > Math.Pow(10, 12))
        {
            return Math.Round(value / Math.Pow(10, 12), 2) + " трл.";
        }
        else if (value > Math.Pow(10, 15))
        {
            return Math.Round(value / Math.Pow(10, 15), 2) + " квдр.";
        }
        else if (value > Math.Pow(10, 18))
        {
            return Math.Round(value / Math.Pow(10, 18), 2) + " квнт.";
        }
        else
        {
            return value + "";
        }
    }
}
