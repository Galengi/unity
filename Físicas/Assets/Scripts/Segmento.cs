using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segmento: MonoBehaviour
{
    const int TOTAL_BLOQUES = 4;
    const string ETIQ_ENEMIGO = "Enemy";
    const float Despl = 0.25f;
    
    //Contiene el cubo de 0.5 unidades de alto
    public GameObject bloque;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ETIQ_ENEMIGO == collision.gameObject.tag)
            fragmentar();
    }

    //Rompe el objeto en diez objetos más pequeños
    void fragmentar()
    {
        Vector3 posicion = transform.position;
        float masaBloque = GetComponent<Rigidbody>().mass / TOTAL_BLOQUES;

        posicion.x -= Despl;
        posicion.z -= Despl; //Current block position - half a block

        for (int x=0; x< 2; x++)
            for (int z = 0; z < 2; z++)
            {
                Instantiate(bloque, posicion, transform.rotation);
                bloque.GetComponent<Rigidbody>().mass = masaBloque;
                posicion.z += Despl*z;
                posicion.x += Despl*x;
            }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
