using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSt : Strengthening
{

    void Start()
    {
        Vector3 pos = transform.position;
        pos.y = 1;
        transform.position = pos;
    }

    void Update()
    {
        Movement();        
    }
    protected override void Movement()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
    }

}
