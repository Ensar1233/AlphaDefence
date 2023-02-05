using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : IController
{

    public bool IsPressed()
    {
        return Input.GetMouseButton(0);
    }

}
