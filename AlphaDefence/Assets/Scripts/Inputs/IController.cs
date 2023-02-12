using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController
{
    public bool IsPressed();
    public bool Click();
    public bool IsJoystickPressed(Transform joystick);
}
