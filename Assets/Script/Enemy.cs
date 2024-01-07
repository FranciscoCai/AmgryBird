using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private GameObject explosionParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
            foreach (Collider col in colliders)
            {

                if (col.gameObject != gameObject)
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Vector3 direction = col.transform.position - transform.position;
                        rb.AddForce(direction.normalized * fuerzaImpulso, ForceMode.Impulse);
                        Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity);
                    }
                }
            }
            MissionDemolition.S.shotsTaken++;
            Destroy(gameObject);
        }
    }
}
