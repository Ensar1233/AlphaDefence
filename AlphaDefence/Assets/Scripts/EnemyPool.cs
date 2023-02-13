using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    [SerializeField] private GameObject target;
    void Start()
    {
        inPool = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < size; i++)
        {
            obj = Instantiate(prefabObject, transform);
            obj.GetComponent<Enemy>().target = target;
            In(obj);
        }
    }
}
