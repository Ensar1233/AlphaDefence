using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengtheningPool : ObjectPool
{
    [SerializeField] protected List<GameObject> sType;
    [SerializeField] protected List<int> sTypeSize;

    protected void Create()
    {
        GameObject st;
        for (int i = 0; i < sType.Count; i++)
        {
            for (int j = 0; j < sTypeSize[i]; j++)
            {
                st = Instantiate(sType[i], transform.position, sType[i].transform.rotation, transform);
                In(st);
            }

        }

    }


}
