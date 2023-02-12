using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    private float radius;

    void Start()
    { 
        radius = transform.parent.GetComponent<SphereCollider>().radius;
        Create();
    }
    public void Create()
    {
        float z = RandomZPosition();
        float x = BoundaryDistanceFromZ(z);// tam uca yerlestiriyor.
        float rand = Random.Range(-x, x);

        transform.localPosition = new Vector3(rand,0,z);
    }
    
    private float BoundaryDistanceFromZ(float z)
    {
        float x = Mathf.Pow(radius, 2) - Mathf.Pow(z, 2);
        return Mathf.Sqrt(x);
    }
    private float RandomZPosition()
    {
        float random = Random.Range(-radius, radius);
        return random;
    }

}
