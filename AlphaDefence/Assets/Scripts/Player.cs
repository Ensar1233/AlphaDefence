using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _joystick;

    private Movement movement;
    private Joystick joystick;
    private IController controller;
    void Start()
    {
        movement = new Movement(transform);
        controller = new MobileController();
        joystick = _joystick.GetComponent<Joystick>();
    }
    void Update()
    {
        if (controller.IsJoystickPressed(joystick.transform))
        {
            movement.Move(joystick.JoystickControl(transform), 5);
        }
    }

    //(1/4)nk2 cot(pi/n)
}
