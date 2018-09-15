using UnityEngine;
using System;

public class DataTranslater : MonoBehaviour
{

    private static string KILLS_SYMBOL = "[KILLS]";
    private static string DEATHS_SYMBOL = "[DEATHS]";

    public static string ValuesToData(int kills, int deaths)
    {
        return KILLS_SYMBOL + kills + "/" + DEATHS_SYMBOL + deaths;
    }
    //returns kills from data passed in from database
    public static int DataToKills(string data)
    {
        return int.Parse(DataToValue(data, KILLS_SYMBOL));
    }
    //returns deaths from data passed in from database
    public static int DataToDeaths(string data)
    {
        return int.Parse(DataToValue(data, DEATHS_SYMBOL));
    }

    private static string DataToValue(string data, string symbol)
    {
        //split at / to get number of pieces in string
        string[] pieces = data.Split('/');
        foreach (string piece in pieces)
        {
            if (piece.StartsWith(symbol))
            {
                //remove symbol so we are only left with the number
                return piece.Substring(symbol.Length);
            }
        }

        Debug.LogError(symbol + " not found in " + data);
        return "";
    }

}