// using System.Collections.Generic;
// using UnityEngine;

// public static class InventorySystem
// {
//     private static HashSet<string> keys = new HashSet<string>();

//     public static void AddKey(string keyID)
//     {
//         keys.Add(keyID);
//         Debug.Log("Sleutel toegevoegd aan inventory: " + keyID);
//     }

//     public static bool HasKey(string keyID)
//     {
//         bool hasKey = keys.Contains(keyID);
//         Debug.Log("Heeft sleutel " + keyID + "? " + hasKey);
//         return hasKey;
//     }
// }


using System.Collections.Generic;
using UnityEngine;

public static class InventorySystem
{
    private static HashSet<string> keys = new HashSet<string>();

    public static void AddKey(string keyID)
    {
        keys.Add(keyID);
        Debug.Log("SLEUTEL TOEGEVOEGD: " + keyID);
    }

    public static bool HasKey(string keyID)
    {
        bool result = keys.Contains(keyID);
        Debug.Log("CHECK SLEUTEL: " + keyID + " = " + result);
        return result;
    }
}