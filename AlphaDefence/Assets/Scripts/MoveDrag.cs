using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrag
{

    private MobileController controller = new MobileController();

    private Vector2 beginPosition;
    private Vector2 direct;

    public Vector2 Value()//telde test edilecek.
    {
        if (controller.IsPressed())
        {
            if (controller.Click())
            {
                beginPosition = Input.GetTouch(0).position;
            }
            direct = Input.GetTouch(0).position - beginPosition;
            return direct.normalized;
        }
        return new Vector2(0, 0).normalized;
    }
}
