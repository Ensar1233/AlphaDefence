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
        controller = new PController();
        joystick = _joystick.GetComponent<Joystick>();
    }
    void Update()
    {
        if(controller.IsPressed())
            movement.Move(joystick.JoystickControl(transform),5);            
    }
}
