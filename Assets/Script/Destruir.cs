using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("desytuir", 1f);
    }

    // Update is called once per frame
    private void desytuir()
    {
        //Slingshot.S.EliminarProyectil(gameObject);
        Destroy(gameObject);
    }
}
