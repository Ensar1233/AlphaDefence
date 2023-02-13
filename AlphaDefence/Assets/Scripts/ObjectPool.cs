using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool:MonoBehaviour
{
    public List<GameObject> inPool;
    public List<GameObject> outPool;
    [SerializeField] protected GameObject prefabObject;
    [SerializeField] protected int size;


    public GameObject In(GameObject obj)
    {
        obj.SetActive(false);
        inPool.Add(obj);
        if (outPool.Count > 0) outPool.Remove(obj);
        return obj;
    }
    public GameObject Out(int index)
    {
        GameObject obj = inPool[index];
        obj.SetActive(true);

        outPool.Add(obj);
        inPool.Remove(obj);

        return obj;
    }
}
