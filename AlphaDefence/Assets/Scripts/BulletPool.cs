using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
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

}
