using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Strengthening : MonoBehaviour
{
    [SerializeField]protected float turnSpeed;

    protected abstract void Movement();

}
