using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour
{
    const float MAX_ANGLE = 270;

    [SerializeField]
    float      walkSpeed;

    GameObject manejadorCanon;

    [SerializeField]
    string     canyon;

    // Start is called before the first frame update
    void Start()
    {
        manejadorCanon  = GameObject.Find(canyon);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Input.GetAxis("Vertical") * Vector3.left * walkSpeed * Time.deltaTime,
                rotation;

        //position.y = suelo.transform.position.y - transform.position.y; 
        //Forward and ackward
        transform.Translate(position);

        //Turn right/left
        transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up, Space.Self);

        if (Input.GetKey(KeyCode.U))    //rotate cannon up
        {
            rotation = manejadorCanon.transform.rotation.eulerAngles;
            print(rotation);
            if (rotation.z > MAX_ANGLE)
                manejadorCanon.transform.Rotate(Vector3.back, Space.Self);
            else {
                    rotation.x = 0.0f;
                    rotation.y = 0.0f;
                    rotation.z = MAX_ANGLE - rotation.z;
                    manejadorCanon.transform.Rotate(rotation, Space.Self);
                 }
        }

        else if (Input.GetKey(KeyCode.J))    //rotate cannon down
        {
            rotation = manejadorCanon.transform.rotation.eulerAngles;
            if (rotation.z < 355.0f && rotation.z >= MAX_ANGLE-15)
                manejadorCanon.transform.Rotate(Vector3.forward, Space.Self);
            else
            {
                rotation = manejadorCanon.transform.rotation.eulerAngles;
                rotation.x = 0.0f;
                rotation.y = 0.0f;
                rotation.z = 355.0f - rotation.z;
                manejadorCanon.transform.Rotate(rotation, Space.Self);
            }
        }
    }
}
