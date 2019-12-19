using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerriboTorre : MonoBehaviour
{
    const string ETIQ_ENEMIGO = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (ETIQ_ENEMIGO == other.gameObject.tag)
        GameObject.Find("Suelo").transform.Translate(Random.insideUnitSphere);
    }

}
