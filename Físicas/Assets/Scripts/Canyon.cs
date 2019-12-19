using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
public class Canyon: MonoBehaviour
{
    //Contiene la bala a disparar
    [SerializeField]
    GameObject bala;

    [SerializeField]
    float potDisp;

    //public float Rx, Ry, Rz;

    Vector3 dirDisparoTanque;

    void Start()
    {
     
    }

    //Rompe el objeto en diez objetos más pequeños
    void disparaBala()
    {
        Vector3    posicion = transform.position,
                   DirDisparo;
        Quaternion rotacion = transform.rotation;
        Rigidbody  balaRB;

        GameObject nuevaBala;

        nuevaBala = Instantiate(bala, posicion, rotacion);
        //nuevaBala.transform.Rotate(Rx, Ry, Rz);
        
        DirDisparo = transform.TransformVector(nuevaBala.transform.rotation.eulerAngles);
        DirDisparo = Vector3.Normalize(DirDisparo);

        balaRB = nuevaBala.GetComponent<Rigidbody>();
        balaRB.AddForce(DirDisparo * potDisp, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //Shoot the cannon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparaBala();
        }

    }
}
