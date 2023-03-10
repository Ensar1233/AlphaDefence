using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    protected float currentHealth;
    public GameObject target;


    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health <= 0)
            {
                AllObjects.AllEnemies.Remove(gameObject);
                transform.parent.GetComponent<ObjectPool>().In(gameObject);
                health = currentHealth;
            }
            health -= value;
        }
    }
    public float Damage
    {
        get
        {
            return damage;
        }
    }
}
