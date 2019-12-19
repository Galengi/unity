using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public Rigidbody rb;
	public float 	VertForce,	//Vertical force applied on the object
					HorForce, 	//Horizontal force applied on the object
					Jump,
					Health;		//Amount of health the playre shows
	
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		//VertForce = 1.0f;
		//HorForce = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() 
	{
		rb.AddForce (Input.GetAxis("Horizontal")*HorForce, 0.0f, Input.GetAxis("Vertical")*VertForce);
	}
}
