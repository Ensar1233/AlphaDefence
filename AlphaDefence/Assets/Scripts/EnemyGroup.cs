using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject enemyPool;

    private PositioningInCircle pin;

    void Start()
    {
        pin = new PositioningInCircle(transform.parent.GetComponent<SphereCollider>().radius);
    }

    void Update()
    {
        if (enemyPool.GetComponent<ObjectPool>().outPool.Count <= 0)
        {
            transform.localPosition = pin.Positioning();
            GameObject enemy;
            ObjectPool t = enemyPool.GetComponent<ObjectPool>();
            for(int i = 0; i < 3; i++)
            {
                enemy = t.Out(Random.Range(0, t.inPool.Count ));
                enemy.transform.position = transform.position;
            }
        }

    }
}
