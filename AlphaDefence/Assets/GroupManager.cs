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
    [Header("References")]
    public List<GameObject> enemyGroups;
    [SerializeField] private GameObject spawnPlane;
    [SerializeField] private GameObject _markers;

    private Coroutine coroutine;
    private Marker sMarker;
    [Header("Time")]
    [SerializeField] float time,currentTime;

    void Start()
    {
        sMarker = _markers.GetComponent<Marker>();    
    }
    void Update()
    {
        if (!AllObjects.AreThereEnemies() && coroutine == null)
        {
            coroutine = StartCoroutine(Positioning());
        }
        else if(!AllObjects.AreThereEnemies() && coroutine != null)
        {

        }
    }
    private int groupSize;
    private float randomTime;

     IEnumerator Positioning()
    {
        groupSize = RandomGroupSize;
        randomTime = RandomTime;

        EnemyGroupPositioning();
        StartCoroutine(PlaceMarker());
        
        yield return new WaitForSeconds(randomTime);
        
        for(int i = 0; i < groupSize; i++)
            enemyGroups[i].SetActive(true);

        sMarker.AllClose();

        coroutine = null;
        yield return null;
    }
    IEnumerator PlaceMarker()
    {
        yield return new WaitForSeconds(randomTime - 1.5f );
        for (int i = 0; i < groupSize; i++)
        {
            sMarker.ShowMarker(sMarker.GetMarker(i), enemyGroups[i]);
        }
    }
    private void EnemyGroupPositioning()
    {
        EnemyGroup enemyGroup;
        for(int i = 0; i < groupSize; i++)
        {
            enemyGroup = enemyGroups[i].GetComponent<EnemyGroup>();
            enemyGroup.pin = new PositioningInCircle(spawnPlane.GetComponent<SphereCollider>().radius);
            enemyGroups[i].transform.localPosition = enemyGroup.pin.Positioning();
        }
    }

    public float RandomTime
    {
        get
        {
            return Random.Range(minTime, maxTime);
        }

    }
    public int RandomGroupSize
    {
        get
        {
            if(gMaxSize>= enemyGroups.Count)
                gMaxSize = enemyGroups.Count;

            return Random.Range(gMinSize, gMaxSize+1);
        }
    }


}
