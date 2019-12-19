using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfil : MonoBehaviour {

    private Animator anim;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            anim.SetBool("Elevado", true);
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
            anim.SetBool("Elevado", false);
    }
}