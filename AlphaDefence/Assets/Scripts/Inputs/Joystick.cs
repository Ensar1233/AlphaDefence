using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Joystick : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float setAngle;
    [SerializeField] private float turnSpeed;

    private PlayerInput playerInput;

    private Vector3 direction;
    private Vector3 beginPosition;

    void Start()
    {
        playerInput = _player.GetComponent<PlayerInput>();
        beginPosition = transform.position;
    }
    
    public Vector3 JoystickControl(Transform player)
    {
        return IsometricController(player);
    }

    public Vector3 IsometricController(Transform player)
    {
        direction = transform.position - beginPosition;// basildigi gibi 55 geliyor bu sorunu cöz.
        
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + setAngle;
        player.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), turnSpeed);
        return player.forward;

    }
    public Vector3 TPSController(Transform player)
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        return move;
    }

}
