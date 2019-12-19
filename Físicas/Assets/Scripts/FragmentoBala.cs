using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoBala : MonoBehaviour
{
    const string ETIQ_ENEMIGO = "Enemy";

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ETIQ_ENEMIGO != collision.gameObject.tag)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
