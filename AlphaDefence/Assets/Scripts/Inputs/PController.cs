using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : IController
{
    public bool Click()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsJoystickPressed(Transform joystick)
    {
        if (IsPressed())
        {
            if (Click()) joystick.position = Input.mousePosition;

            if (joystick.GetComponent<Joystick>().Tan2 != 0) return true;

        }

        return false;
    }

    public bool IsPressed()
    {
        return Input.GetMouseButton(0);
    }

}
