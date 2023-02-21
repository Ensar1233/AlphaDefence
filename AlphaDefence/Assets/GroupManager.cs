using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    [Header("Spawn Time")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [Header("Group Size")]
    [SerializeField] private int gMinSize;
    [SerializeField] private int gMaxSize;


    public float Time
    {
        get
        {
            return RandomTime(minTime, maxTime);
        }
    }

    public static float RandomTime(float min,float max)
    {
        return Random.Range(min, max);
        
    }
}
