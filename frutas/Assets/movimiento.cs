using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 6.0F;
    public GameObject cesta;
    public Text countText;
    public Text winText;
    public int count;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Start ()
    {
        count = 0;
        SetCountText();
        winText.text = "";
        cesta = GameObject.Find("Cesta");
        
    }
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    public void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
            cesta.GetComponent<movimiento>().enabled = false;
            Time.timeScale = 0;
        }
    }

    public void IncrementarPuntos() {
        
        count = count + 1;
        SetCountText ();
    }
}
