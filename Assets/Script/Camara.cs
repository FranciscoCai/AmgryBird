using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public static GameObject POI;
    [SerializeField] private float camZ;
    [SerializeField] private float easing;
    [SerializeField] private Vector2 minxy = Vector2.zero;
    void Awake()
    {
        camZ = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        destination.x = Mathf.Max(minxy.x,destination.x);
        destination.y = Mathf.Max(minxy.y, destination.y);
        destination = Vector2.Lerp(transform.position, destination, easing);

        

        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
