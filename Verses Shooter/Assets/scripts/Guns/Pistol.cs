using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float range;
    [Space]
    public bool automatic;
    [Space]
    public Camera cam;

    private float nextFire;

    bool canFire;

    void Update()
    {
        if (nextFire > 0)
        {
            canFire = false;
            nextFire -= Time.deltaTime;
        }
        else
        {
            canFire = true;
        }

        if (Input.GetButtonDown("Fire1") && canFire && gameObject.GetComponentInParent<PlayerSetup>().localPlayer)
        {
            Debug.Log("Went bang bang!");
            nextFire = 1 / fireRate;

            Fire();
        }
    }

    void Fire()
    {
        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, range))
        {
            if (hit.transform.gameObject.GetComponent<Health>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                Debug.Log("hit something");
            }
        }
    }
}
