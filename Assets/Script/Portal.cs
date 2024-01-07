using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject linkedPortal; // Referencia al otro portal

    private void OnTriggerEnter(Collider collision)
    {
      
        Rigidbody rb = collision.GetComponent<Rigidbody>();
        if (collision.CompareTag("Projectile"))
        {
            Vector2 currentVelocity = rb.velocity;

            collision.transform.position = linkedPortal.transform.position;

            rb.velocity = linkedPortal.transform.up * currentVelocity.magnitude;
        }
    }

}
