using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rey : MonoBehaviour {

    public float speed;
    Vector2 touchDeltaPosition;
    Vector3 direction;
    
    // Use this for initialization
    void Start () {
		
	}	

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            // Get movement of the finger since last frame
             touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        else touchDeltaPosition = Vector2.zero;

        direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        direction.x += touchDeltaPosition.x;
        direction.z += touchDeltaPosition.y;

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
