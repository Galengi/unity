using UnityEngine;
using System.Collections;

public class PerSeg : MonoBehaviour {

    NPCScript   NPCS;
    GameObject  Player,         //Player 
                NPC;
  
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");

        NPC = GameObject.Find("NPC");
        NPCS = NPC.GetComponent<NPCScript>();	
	}
	
    //// Update is called once per frame
        void Update () {
            if (transform.position.y < 1.0f)
                Destroy(gameObject);
        }

	void OnTriggerEnter(Collider collider)
	{
		GameObject GO = collider.gameObject;

        if (GO.name == Player.name)
            //Player collided
            NPCS.PlayerNear();
	}

    void OnTriggerExit(Collider collider)
    {
        GameObject GO = collider.gameObject;

        if (GO.name == Player.name)
            NPCS.PlayerGone();
    }

    void OnCollisionEnter()
    {
        print("Ha habido una colisión");
    }

    void OnCollisionEnter(Collision ObjectCollided)
    {
        GameObject GO = ObjectCollided.contacts[0].otherCollider.gameObject;

        if (GO.tag == "Target")
        {
            print("Ha habido una colisión");
            Mesh m = GO.GetComponent<MeshFilter>().mesh;
            print("Tamaño del objeto colisionado = " + m.bounds.size);
            MeshRenderer mr = GO.GetComponent<MeshRenderer>();
            mr.material.color *= 1.2f;
        }
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }
}
