using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraType : MonoBehaviour
{
    
    [SerializeField] private GameObject isometricCam;
    [SerializeField] private GameObject tpsCam;
    public enum Type {Isometric,TPS };

    private CinemachineBrain cb;
    private CinemachineVirtualCamera cvc;
    void Start()
    {
        cb = Camera.main.GetComponent<CinemachineBrain>();
        cvc = tpsCam.GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {

        if (AllObjects.AreThereEnemies())
        {
            isometricCam.SetActive(false);
            tpsCam.SetActive(true);
        }
        else
        {
            isometricCam.SetActive(true);
            tpsCam.SetActive(false);
        }
    }
    public bool TPSCam
    {
        get
        {
            return cb.IsLive(cvc);
        }
    }

}
