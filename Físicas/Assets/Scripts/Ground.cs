using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{   [SerializeField]
    float tiltForce;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Vector3 dir = Random.insideUnitSphere;
            dir.y *= 0.2f;

        transform.Translate(dir * tiltForce);
        }
    }
}
