using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _joystick;
    [SerializeField] Transform enemyPool;
    [SerializeField] GameObject cameraManager;
    [SerializeField] float turnSpeed;

    private Joystick joystick;
    private CameraType camType;
    void Start()
    {
        joystick = _joystick.GetComponent<Joystick>();
        camType = cameraManager.GetComponent<CameraType>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (AllObjects.AreThereEnemies())
        {
            Vector3 target = AllObjects.AllEnemies[0].transform.position - transform.position;
            transform.forward = Vector3.Lerp(transform.forward, target, turnSpeed);
            
           if(MobileController.IsPressed()) joystick.TPSControllerr();

            Vector3 pos = transform.position;
            pos.y = 1.35f;
            transform.position = pos;
            }
        else if (!AllObjects.AreThereEnemies())
        {
            if(MobileController.IsPressed() && !camType.TPSCam) if(joystick.Tan2 != 0) joystick.IsometricControllerr();
        }

    }

}
