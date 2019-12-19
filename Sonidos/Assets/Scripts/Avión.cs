using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avión : MonoBehaviour
{
    public float radioVuelo;
    float velocidadAngular = 60.0f, //en grados por segundo
          angulo = 0.0f,
          altura = 5.0f;
    Vector3 rotationCenter = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angulo = velocidadAngular * Time.deltaTime;
        //if (angulo > 360.0f) angulo -= 360.0f;

        //Kinematic object
        transform.RotateAround(rotationCenter, Vector3.up, angulo);
    }
}
