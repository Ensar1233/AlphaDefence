using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{

    private PositioningInCircle pin;
    void Start()
    {
        pin = new PositioningInCircle(transform.parent.GetComponent<SphereCollider>().radius);

        InvokeRepeating("Position", 0.5f, 6);
    }
    private void Position()
    {
        transform.localPosition = pin.Positioning();
    }

}
