using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] GroupManager groupManager;
    [SerializeField] GameObject _marker;
    private TimeOperations timeOp = new TimeOperations();
    void Start()
    {
        GameObject marker;
        for(int i = 0; i < groupManager.enemyGroups.Count; i++)
        {
            marker = Instantiate(_marker, transform.position, _marker.transform.rotation , transform);
            marker.SetActive(false);
        }
    }

    public void AllClose()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public GameObject GetMarker(int index)
    {

        return transform.GetChild(index).gameObject;
    }

    public void ShowMarker(GameObject marker,GameObject obj)
    {
        marker.transform.position = obj.transform.position;
        marker.SetActive(true);
    }
   
}
