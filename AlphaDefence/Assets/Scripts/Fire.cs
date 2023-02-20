using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float firingRate;
    [SerializeField] private Transform bullets;
    private float currentFiringRate = 2;
    private ObjectPool pool;
    void Start()
    {
        pool = bullets.GetComponent<ObjectPool>();
    }

    void Update()
    {
        if (AllObjects.AreThereEnemies())
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (FiringRate())
        {
           GameObject bullet = pool.Out(0);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, transform.parent.rotation.eulerAngles.y, 0);
        }
    }
    private bool FiringRate()
    {
        if(Time.time >= currentFiringRate)
        {
            currentFiringRate = 0;
            currentFiringRate += Time.time+ firingRate;
            return true;
        }

        else return false;
    }

}
