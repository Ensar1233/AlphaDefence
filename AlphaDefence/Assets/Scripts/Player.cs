using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _joystick;
    [SerializeField] Transform enemyPool;

    private Joystick joystick;
    void Start()
    {
        joystick = _joystick.GetComponent<Joystick>();
    }
    // Bir tane AllObjects sinifinin icinde AllEnemies sinifinin 0 dan büyük mü esitmi olacaginin kontrolü yapilacak.
    // Kontrolden sonra ChangeCamera sinifi olusturalacak.
    // ChangeController Sinifi , yapilan kontrol ile camera input kontrollerini degistirecek. 
    void Update()
    {
        if (MobileController.IsPressed())
        {
            if (AllObjects.AllEnemies.Count > 0)
            {
                transform.forward = AllObjects.AllEnemies[0].transform.position - transform.position;
                joystick.TPSControllerr();

                Vector3 pos = transform.position;
                pos.y = 1.35f;
                transform.position = pos;
            }
            else if (joystick.Tan2 != 0 && AllObjects.AllEnemies.Count== 0)
            {
                joystick.IsometricControllerr();
            }

        }
    }
}
