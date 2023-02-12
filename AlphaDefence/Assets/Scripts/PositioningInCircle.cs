using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningInCircle
{
    private float radius;
    public PositioningInCircle(float radius)
    {
        this.radius = radius;
    }

    public Vector3 Positioning()
    {
        float z = RandomZPosition();
        float x = BoundaryDistanceFromZ(z);
        float rand = Random.Range(-x, x);

        return new Vector3(rand, 0, z);
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
