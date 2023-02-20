using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _joystick;
    [SerializeField] Transform enemyPool;
    [SerializeField] float turnSpeed;
    private Joystick joystick;
    void Start()
    {
        joystick = _joystick.GetComponent<Joystick>();

        //Camera.main.GetComponent<CinemachineBrain>().IsLive
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // buranin basmadan da forwarda kitlenmesi gerek.
        if (MobileController.IsPressed())
        {
            if (AllObjects.AreThereEnemies())
            {
                transform.forward = AllObjects.AllEnemies[0].transform.position - transform.position;
                joystick.TPSControllerr();

                Vector3 pos = transform.position;
                pos.y = 1.35f;
                transform.position = pos;
            }
            else if (joystick.Tan2 != 0 && !AllObjects.AreThereEnemies())
            {
                joystick.IsometricControllerr();
            }

        }
    }

}
