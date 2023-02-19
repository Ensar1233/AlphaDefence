using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController
{
    private static Vector2 beginPos;
    public static bool IsPressed()
    {
        return Input.touchCount > 0;
    }
    
    public static bool Click()
    {

        return Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
