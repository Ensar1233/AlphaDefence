using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Transform transform;
    public Movement(Transform transform)
    {
        this.transform = transform;
    }
    
    public void Move(Vector3 dir,float speed)
    {
        transform.position += dir * speed * Time.deltaTime;
    }

}
