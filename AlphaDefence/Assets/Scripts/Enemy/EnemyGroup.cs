using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject enemyPool;
    [SerializeField] private GameObject groupManager;
    // Group Manager enemyGroup objeleri pasif hale getirilecek.
    // Pasif hale getirilien objeler group managerde belirtilen surede aktif hale getirilecektir.
    private int size;
    [Header("Spawn size")]
    public int minSize;
    public int maxSize;

    private Coroutine coroutine;
    private PositioningInCircle pin;
    private GroupManager sGroupManager;
    void Start()
    {
        pin = new PositioningInCircle(transform.parent.GetComponent<SphereCollider>().radius);
        sGroupManager = groupManager.GetComponent<GroupManager>();
    }

    void Update()
    {
        if (!AllObjects.AreThereEnemies() && coroutine==null)
        {
            coroutine = StartCoroutine(Positioning());
        }
    }

    IEnumerator Positioning()
    {
        yield return new WaitForSeconds(sGroupManager.Time);
        size = Random.Range(minSize, maxSize);

        transform.localPosition = pin.Positioning();
        GameObject enemy;
        ObjectPool t = enemyPool.GetComponent<ObjectPool>();//EnemyPool
        for (int i = 0; i < size; i++)
        {
            enemy = t.Out(Random.Range(0, t.inPool.Count));
            enemy.transform.position = transform.position;
            AllObjects.AllEnemies.Add(enemy);

            enemy.transform.position = CircularArray(enemy.transform.position, i);
        }
        coroutine = null;

        yield return null;
    }

    private Vector3 CircularArray(Vector3 pos,int index)
    {
        Vector3 v = pos;
        v.x += 1.25f * Mathf.Sqrt(index) * Mathf.Cos(index * 0.5f);
        v.y = 1.35f;
        v.z += 1.25f * Mathf.Sqrt(index) * Mathf.Sin(index * 0.5f);
        return v;            
    }

}
