using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque: MonoBehaviour
{
    const string ETIQ_ENEMIGO = "Enemy";
    const int TOTAL_SEGMENTOS = 10;
    const float ALTO_SEGMENTO = 0.5f;

    //Contiene el cubo de 0.5 unidades de alto
    public GameObject segmento;

    void Start()
    {

    }
        
    private void OnCollisionEnter(Collision collision)
    {
        GameObject objColisionado = collision.gameObject;

        if (ETIQ_ENEMIGO == objColisionado.tag)
        {
            fragmentar();
            //print("Ha habido una colisión con el objeto " + objColisionado.name);
            //Mesh m = objColisionado.GetComponent<MeshFilter>().mesh;
            //print(" y el tamaño del objeto es " + m.bounds.size);
            ////Modifica el color del objeto colisionado aumentando su intesidad en un 20%
            //objColisionado.GetComponent<Renderer>().material.color *= 1.2f;
        }
    }

    //Rompe el objeto en diez objetos más pequeños
    void fragmentar()
    {
        float masaSegmento = GetComponent<Rigidbody>().mass / TOTAL_SEGMENTOS;
        float y = -2.0f;//Current block position - half a block + half a segment

        for (int i=0; i< TOTAL_SEGMENTOS; i++)
        {
            Instantiate(segmento, transform.position, transform.rotation);
            segmento.transform.Translate(0.0f, y, 0.0f, Space.Self);
            segmento.GetComponent<Rigidbody>().mass = masaSegmento;
            y += ALTO_SEGMENTO;
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
