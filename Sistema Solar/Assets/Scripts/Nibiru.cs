using UnityEngine;
using System.Collections;

public class Nibiru : MonoBehaviour {

	Vector3 Speed;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		Speed = new Vector3(0.0f, 0.0f, 5.0f);
		GetComponent<Rigidbody>().AddForce (new Vector3(0,0,100));
		GetComponent<Rigidbody>().AddTorque (transform.up * 100);

		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0f, 360.0f/15.0f* Time.deltaTime, 0.0f);
		transform.position += Speed * Time.deltaTime;
	}

	void FixedUpdate () {
		//GetComponent<Rigidbody>().AddForce (new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")));
	}

	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.red);
		}

		rend.material.color = Color.blue;
	}

	void OnTriggerEnter(Collider other) {
		rend.material.color = Color.red;
	}
	
}