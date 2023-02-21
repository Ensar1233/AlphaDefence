using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Joystick : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float setAngle;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float speed;
    private PlayerInput playerInput;

    private Vector3 direction;
    private Vector3 beginPosition;
    private MoveDrag drag;
    [SerializeField] CameraType.Type cameraType; 

    void Start()
    {
        playerInput = _player.GetComponent<PlayerInput>();
        beginPosition = transform.position;
        drag = new MoveDrag();
    }
    
   
    public void IsometricControllerr()
    {
            float angle = Tan2 + setAngle;

            _player.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), turnSpeed);
            _player.position += _player.forward * speed * Time.deltaTime;
    }
    public void TPSControllerr()
    {
            Vector2 dragPos = drag.Value();

            Vector3 move = new Vector3(dragPos.x, 0, dragPos.y);
            _player.Translate(move * speed * Time.deltaTime);
    }
            

    public void IsJoystickPressed()
    {
        if (MobileController.Click())
        {
            transform.position = Input.GetTouch(0).position;
        }
    }

    public float Tan2
    {
        get
        {
            IsJoystickPressed();

            beginPosition = Input.GetTouch(0).position;
            direction = beginPosition - transform.position;

            float tan2 = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;//ilk bastaki
            return tan2;
        }
    }


}
