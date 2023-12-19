using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform portal;
    private Rigidbody rb;
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Vector3 DirectionPortal = portal.forward;
            rb = other.GetComponent<Rigidbody>();
            other.transform.position = portal.transform.position;
            rb.velocity *= DirectionPortal;
        }
    }

}
