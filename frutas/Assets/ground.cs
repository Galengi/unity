using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public movimiento cestaCont;
    public GameObject cesta;
    // Start is called before the first frame update

    void Awake()
    {
        cesta = GameObject.Find("Cesta");
        cestaCont = cesta.GetComponent<movimiento>();
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "GROUND") {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "CESTA") {
            Destroy(gameObject);
            cestaCont.IncrementarPuntos();
        }
    }
}
