using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaImpulso;
    void Start()
    {
        Invoke("desytuir", 1f);
    }

    // Update is called once per frame
    private void desytuir()
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
                }
            }
        }
        Destroy(gameObject);
    }
}
