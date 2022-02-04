using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPush : MonoBehaviour
{
    float radius = 50f;
    float power = 1000f;
    
    // When player presses E, launch nearby objects
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            // Get all objects within radius
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            // For each object, push it
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius);
                }
            }
        }
    }
}
