using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float bulletSpeed = 40f;

    void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
    }
    
    void Update()
    {
        
    }
}
