using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Test : MonoBehaviour
{
    private PlayerInput playerInput;

    
    [SerializeField] private Transform joistic;
    [SerializeField] private float setAngle;
    [SerializeField] private float turnSpeed;
    private Vector3 beginPos;
    private Vector3 direction;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        beginPos = joistic.position;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            direction = joistic.position - beginPos;

            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + setAngle;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), turnSpeed);

            transform.position += transform.forward * 5 * Time.deltaTime; 

            Debug.Log(angle);
            Debug.DrawRay(beginPos, direction, Color.green);

        }
    }
}
