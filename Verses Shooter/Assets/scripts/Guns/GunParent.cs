using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GunParent : MonoBehaviour
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

        //checks if automatic is true, and lets the player hold down fire if true
        if (automatic)
        {
            if (Input.GetButton("Fire1") && nextFire <= 0 && gameObject.GetComponentInParent<PlayerSetup>().localPlayer)
            {
                Debug.Log("Going bang bang!");
                nextFire = 1 / fireRate;

                Fire();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && nextFire <= 0 && gameObject.GetComponentInParent<PlayerSetup>().localPlayer)
            {
                Debug.Log("Went bang bang!");
                nextFire = 1 / fireRate;

                Fire();
            }
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
