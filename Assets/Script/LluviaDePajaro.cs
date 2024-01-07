using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LluviaDePajaro : MonoBehaviour
{
    [SerializeField] private GameObject Birds;
    private Rigidbody Rb;
    [SerializeField] private Vector3 VelocidadDelPajaro;
    void Start()
    {
        for (int i = 0; i <3;  i++)
        {
            GameObject toInstantiate = Instantiate(Birds, 
            new Vector2(Random.Range(gameObject.transform.position.x +3f, gameObject.transform.position.x -3f),
            Random.Range(gameObject.transform.position.y + 15f, gameObject.transform.position.y + 12f)), Quaternion.identity);
            Rb = toInstantiate.GetComponent<Rigidbody>();
            Rb.AddForce(VelocidadDelPajaro, ForceMode.Impulse);
        }

        Destroy(gameObject);
    }
}
