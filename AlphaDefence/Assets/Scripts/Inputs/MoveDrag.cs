using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrag
{

    private Vector2 beginPosition;
    private Vector2 direct;
    Transform joystick;
    //global beginPos Al;
    public Vector2 Value()
    {
        if (MobileController.Click())
        {
            beginPosition = Input.GetTouch(0).position;
        }
            direct = Input.GetTouch(0).position -beginPosition;

        return direct.normalized;
    }
}
