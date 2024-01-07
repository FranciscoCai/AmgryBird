using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static public Slingshot S;

    [SerializeField] private GameObject[] prefabproyectile;
    [SerializeField]  private int NumeroDeInstancia = 0;
    [SerializeField] private float velocityMult = 8f;

    private GameObject launchPoint;
    private Vector3 launchPos;
    private GameObject proyectile;
    static public bool aimingMode;
    private Rigidbody rb;
    
    
    private void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }
    private void OnMouseEnter()
    {
        Debug.Log("MouseEnter");
        launchPoint.SetActive(true);
    }
    private void OnMouseExit()
    {
        Debug.Log("MouseExit");
        launchPoint.SetActive(false);
    }
    private void OnMouseDown()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        aimingMode = true;
       
        proyectile = Instantiate(prefabproyectile[NumeroDeInstancia]);
        NumeroDeInstancia++;
        if (NumeroDeInstancia > prefabproyectile.Length-1)
        {
            NumeroDeInstancia = 0;
        }
        rb = proyectile.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
   
    private void Update()
    {
        DisparoProyectil();
    }
    private void DisparoProyectil()
    {
        if (!aimingMode) { return; }
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagnitud = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitud)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitud;
        }
        Vector3 posProj = launchPos + mouseDelta;
        proyectile.transform.position = posProj;
        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            rb.isKinematic = false;
            rb.velocity = -mouseDelta * velocityMult;

            MissionDemolition.ShotFired();
            Camara.POI = proyectile;
            
            proyectile = null;
        }
    }
}

