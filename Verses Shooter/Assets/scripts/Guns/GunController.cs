using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public MonoBehaviour[] guns;
    public int activeWeaponIndex = 0;
    public MonoBehaviour activeWeapon = null;

    public Pistol pistol;
    public Rifle rifle;

    void Start()
    {
        pistol = GetComponent<Pistol>();
        rifle = GetComponent<Rifle>();
        activeWeapon = pistol;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeaponIndex = 0;
            guns[0].enabled = true;
            guns[1].enabled = false;
            Debug.Log("active wepon changed to " + activeWeaponIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeaponIndex = 1;
            guns[0].enabled = false;
            guns[1].enabled = true;
            Debug.Log("active wepon changed to " + activeWeaponIndex);
        }

        activeWeapon = guns[activeWeaponIndex];

        /*
        activeWeapon.enabled = false;
         activeWeapon.enabled = true;
        */
        
    }
}
