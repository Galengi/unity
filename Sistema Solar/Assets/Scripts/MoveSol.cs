using UnityEngine;
using System.Collections;

public class MoveSol : MonoBehaviour {

	enum State {Init, Idle, Running, Dead}

	private State state;
	public Renderer rend;

    private float lastTime;
    private int life;
    readonly int MAX_LIFE = 5; //Constante durante toda la ejecución del juego

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Rigidbody>().AddTorque (transform.up * 100);
		state = new State ();
		state = State.Init;
		rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
		AI ();
	}

	void AI ()
	{
		//Sun Behaviour

		switch (state) {
		case State.Init:
                print("Start ");
                print("First Idle ");
                state = State.Idle;
                lastTime = Time.realtimeSinceStartup;
                break;
        case State.Dead:
			break;
		case State.Idle:
            if (Time.realtimeSinceStartup - lastTime > 1.0)
            {
                state = State.Running;
                Debug.Log("Running ");
                lastTime = Time.realtimeSinceStartup;
                if (life > MAX_LIFE)
                {
                    print("Dead ");
                    state = State.Dead;
                }
                else
                {
                    print("Life = " + life);
                    life++;
                }
            }
            break;
        case State.Running:
            if (Time.realtimeSinceStartup - lastTime > 3.0)
            {
                lastTime = Time.realtimeSinceStartup;
                state = State.Idle;
                print("Idle ");
                }
                break;
            default:
			break;
		}
	}

	void OnTriggerEnter(Collider other) {
 		rend.material.color = Color.red;
	}
}
