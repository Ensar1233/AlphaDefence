using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjects
{

    public static List<GameObject> AllEnemies = new List<GameObject>();


    public static bool AreThereEnemies()
    {
        if (AllEnemies.Count > 0)
            return true;
        else if(AllEnemies.Count <= 0)
            return false;
        return false;
    }

}
