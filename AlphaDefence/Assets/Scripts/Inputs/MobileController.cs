using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : IController
{

    public bool IsPressed()
    {
        return Input.touchCount > 0;
    }
    
    public bool Click()
    {

        return Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public  bool IsJoystickPressed(Transform joystick)
    {
        if (IsPressed())
        {
            if (Click()) joystick.transform.position = Input.GetTouch(0).position;

            if (joystick.GetComponent<Joystick>().Tan2 != 0) return true;

        }

        return false;
    }

}
