using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public static class Config
{
    public static string lastResults = "";

    /*public static bool isAllCheck()
    {
        return b1 && b2 && b3;
    }*/
    public static bool detector;
    public static bool map;
    public static bool door;
    public static bool extinguisher;
    public static bool callFirefighters;
    public static bool pressFireAlarm;
    public static bool checkForPeople;
    public static bool extinguishFire;
    public static bool leaveBuilding;

    public static event Action OnVariableChange;

    public static void DelBool()
    {
        bool detector = false;
        bool map = false;
        bool door = false;
        bool extinguisher = false;
        bool callFirefighters = false;
        bool pressFireAlarm = false;
        bool checkForPeople = false;
        bool extinguishFire = false;
        bool leaveBuilding = false;
    }

    public static bool GetVariable(ConfigVariables variable)
    {
        switch (variable)
        {
            case ConfigVariables.Detector:
                return detector;
            case ConfigVariables.Map:
                return map;
            case ConfigVariables.Door:
                return door;
            case ConfigVariables.Extinguisher:
                return extinguisher;
            default:
                throw new ArgumentException("Unknown variable");
        }
    }
    
    public static void SetVariable(string name, bool value)
    {
        switch (name)
        {
            case "detector":
                detector = value;
                break;
            case "map":
                map = value;
                break;
            case "door":
                door = value;
                break;
            case "extinguisher":
                extinguisher = value;
                break;
            case "callFirefighters":
                callFirefighters = value;
                break;
            case "pressFireAlarm":
                pressFireAlarm = value;
                break;
            case "checkForPeople":
                checkForPeople = value;
                break;
            case "extinguishFire":
                extinguishFire = value;
                break;
            case "leaveBuilding":
                leaveBuilding = value;
                break;
        }

        OnVariableChange?.Invoke();
    }

    public enum ConfigVariables
    {
        Detector,
        Map,
        Door,
        Extinguisher
    }

    public static bool AllVariablesTrue()
    {
        return detector && map && door && extinguisher;
    }

    public static void SetVariable(ConfigVariables variable, bool value)
    {
        switch (variable)
        {
            case ConfigVariables.Detector:
                detector = value;
                break;
            case ConfigVariables.Map:
                map = value;
                break;
            case ConfigVariables.Door:
                door = value;
                break;
            case ConfigVariables.Extinguisher:
                extinguisher = value;
                break;
        }
    }

    public static void saveGame()
    {
        PlayerPrefs.SetString("lastResults", lastResults);
    }
}