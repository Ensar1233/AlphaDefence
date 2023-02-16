using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _joystick;
    [SerializeField] Transform enemyPool;
    private Joystick joystick;
    private IController controller;
    void Start()
    {
        controller = new MobileController();
        joystick = _joystick.GetComponent<Joystick>();
    }
    void Update()
    {
        if (enemyPool.GetComponent<ObjectPool>().outPool.Count > 0)
        {
            transform.forward = enemyPool.GetComponent<ObjectPool>().outPool[0].transform.position - transform.position;

            Vector3 pos = transform.position;
            pos.y = 1.35f;
            transform.position = pos;
        }
        
        if (controller.IsJoystickPressed(joystick.transform))
        {
            if (enemyPool.GetComponent<ObjectPool>().outPool.Count > 0)
            {
                joystick.TPSControllerr();
            }
            else 
            {
                joystick.IsometricControllerr();
            }
        }
        
    }
}
