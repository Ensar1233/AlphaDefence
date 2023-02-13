using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> inPool;
    public List<GameObject> outPool;
    [SerializeField] private GameObject prefabObject;
    [SerializeField] private int size;


    void Start()
    {
        inPool = new List<GameObject>();

        GameObject obj;
        for (int i = 0; i < size; i++)
        {
            obj = Instantiate(prefabObject, transform);
            In(obj);
        }
    }
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
