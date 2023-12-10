using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFXController : MonoBehaviour
{
    float timeTillDelete = 0.5f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTillDelete -= Time.deltaTime;

        if (timeTillDelete <= 0)
        {
            Destroy(gameObject);
        }
    }
}
