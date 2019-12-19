using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float jumpForce;

    enum States {IDLE, JUMPING, FALLING, MAX_STATES };
    States state = States.IDLE;

    Rigidbody  rigidBody;
    GameObject larguero, capsula;

    float yPos;

    // Start is called before the first frame update
    void Start()
    {
        //define the animator attached to the player
        rigidBody = GetComponent<Rigidbody>();
        larguero = GameObject.Find("Travesaño 1.edif2");
        capsula   = GameObject.Find("Capsula");
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Ball state machine behaviour
        switch (state)
        {
            case States.JUMPING:
                if (yPos > transform.position.y)
                    state = States.FALLING;
                else yPos = transform.position.y;
                break;
            case States.FALLING:
                if (yPos == transform.position.y)
                    state = States.IDLE;
                else yPos = transform.position.y;
                break;
            case States.IDLE:
                if (Input.GetButton("Jump"))
                {
                    rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    state = States.JUMPING;
                }
                break;
        }
        
        //The rest of the inputs
        if (Input.GetKey(KeyCode.Z))
        {
            capsula.GetComponent<Rigidbody>().Sleep();
            larguero.transform.Translate(Vector3.forward * 2.0f);
        }

        if (Input.GetKey(KeyCode.X))
        {
            capsula.GetComponent<Rigidbody>().WakeUp();
            larguero.transform.Translate(Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
    //    rigidBody.AddForce(Input.GetAxis("Vertical") * walkSpeed, 0.0f, -Input.GetAxis("Horizontal") * walkSpeed);
    }
}
