using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    [SerializeField] private GameObject target;

    [SerializeField]  List<GameObject> prefabObjects;
    [SerializeField] List<int> sizes;

    void Start()
    {
        inPool = new List<GameObject>();
        Create();
    }

    public void Create()
    {
        GameObject obj;
        for(int i = 0; i < prefabObjects.Count; i++)
        {
            for(int j = 0; j < sizes[i]; j++)
            {
                obj = Instantiate(prefabObjects[i], transform);
                obj.GetComponent<Enemy>().target = target;
                In(obj);

            }
        }
    }
}
