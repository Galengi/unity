using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    const string ETIQ_ENEMIGO = "Enemy";

    [SerializeField]
    GameObject PartesBala;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotacion;
        
        //rotacion = new Vector3(Mathf.Atan(rb.velocity.y / rb.velocity.z) * Mathf.Rad2Deg, 0.0f, 0.0f);
        //rotacion.x -= transform.rotation.eulerAngles.x;

        //// Sets the transforms rotation to rotate 30 degrees around the y-axis
        //transform.rotation = Quaternion.AngleAxis(Mathf.Atan(rb.velocity.y / rb.velocity.z) * Mathf.Rad2Deg, Vector3.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
       // if (ETIQ_ENEMIGO != collision.gameObject.tag)
        {
            Instantiate(PartesBala, transform.position, transform.rotation);

            Component[] hijos;
            Transform[] hijosT;

            Rigidbody rbPropio = GetComponent<Rigidbody>();

            hijos = PartesBala.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in hijos)
                rb.velocity = rbPropio.velocity;

            hijosT = PartesBala.GetComponentsInChildren<Transform>();

            foreach (Transform t in hijosT)
                t.parent = null;

            Destroy(PartesBala);
            Destroy(gameObject);
        }
    }
}
