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
    [Header("VFX")]
    public GameObject hitVFX;

    private float nextFire;

    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && nextFire <= 0 && gameObject.GetComponentInParent<PlayerSetup>().localPlayer)
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
            //Instantiates the particle when a shot hits
            PhotonNetwork.Instantiate(hitVFX.name, hit.point, Quaternion.identity);

            //does damage if it hit a player
            if (hit.transform.gameObject.GetComponent<Health>())
            {
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                Debug.Log("hit " + hit.transform.gameObject.GetComponent<PhotonView>().ViewID);
            }
        }
    }
}
