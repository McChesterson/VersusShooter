using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    public float fireRate = 1f;
    public bool fireReady = true;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && fireReady)
        {
            StartCoroutine("FireDelay");
        }
    }
    IEnumerator FireDelay()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireReady = false;
        yield return new WaitForSeconds(fireRate);
        fireReady = true;
    }
}
