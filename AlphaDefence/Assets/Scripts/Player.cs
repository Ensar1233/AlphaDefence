using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _joystick;
    [SerializeField] Transform enemyPool;
    [Header("Managers")]
    [SerializeField] GameObject cameraManager;
    [Header("Movement")]
    [SerializeField] float turnSpeed;
    [Header("Strengthening")]
    public List<GameObject> strengthenings;

    public float health = 100;
    public float damage = 100;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            if (strengthenings.Count == 0)
            {
                health -= other.GetComponent<Enemy>().Damage;
                if (health <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                other.GetComponent<Enemy>().Health = damage;
                strengthenings.Remove(strengthenings[0]);
            }
        }
        if (other.GetComponent<Strengthening>())
        {
            strengthenings.Add(other.gameObject);
            other.transform.parent.GetComponent<ObjectPool>().In(other.gameObject);
        }
    }

}
