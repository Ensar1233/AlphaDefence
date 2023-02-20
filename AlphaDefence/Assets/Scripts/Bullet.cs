using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField] private float speed;
    void Update()
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;

    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

}
