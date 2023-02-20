using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraType : MonoBehaviour
{
    
    //[SerializeField] private GameObject enemyPool;
    [SerializeField] private GameObject isometricCam;
    [SerializeField] private GameObject tpsCam;
    public enum Type {Isometric,TPS };

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


}
