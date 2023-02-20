using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {

            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Health = GetComponent<Bullet>().Damage;

            transform.parent.GetComponent<ObjectPool>().In(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            transform.parent.GetComponent<ObjectPool>().In(gameObject);
        }
    }
}
