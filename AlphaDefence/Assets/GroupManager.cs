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

    [SerializeField] private List<GameObject> enemyGroups;

    private Coroutine coroutine;
    void Update()
    {
        if (!AllObjects.AreThereEnemies() && coroutine == null)
        {
            coroutine = StartCoroutine(Positioning());
        }
    }

     IEnumerator Positioning()
    {
        yield return new WaitForSeconds(RandomTime);
        
        for(int i = 0; i < RandomGroupSize; i++)
            enemyGroups[i].SetActive(true);

        coroutine = null;

        yield return null;
    }

    public float RandomTime
    {
        get
        {
            return Random.Range(minTime, maxTime);
        }

    }
    public float RandomGroupSize
    {
        get
        {
            if(gMaxSize>= enemyGroups.Count)
                gMaxSize = enemyGroups.Count;

            return Random.Range(gMinSize, gMaxSize+1);
        }
    }


}
