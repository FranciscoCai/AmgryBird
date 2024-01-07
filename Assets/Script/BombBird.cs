using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : MonoBehaviour
{
    [SerializeField] private GameObject LluviaDePajaro;
    void Update()
    {
        // Verifica si la tecla "E" est¨¢ siendo presionada en este frame
        if (Input.GetKeyDown(KeyCode.E) && Slingshot.aimingMode == false)
        {
            Instantiate(LluviaDePajaro,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y +10f),Quaternion.identity);
            Destroy(gameObject);    
        }
    }
}
