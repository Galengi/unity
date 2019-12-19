using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

    public enum States
    { 
        PAUSADO,
        HUIR,
        SALTAR_HUIR,
        CORRER,
        SALTAR_CORRER,
        MATAR,
        MORIR,
        TOTAL_ESTADOS
    };

    float Jump;
    public Rigidbody rb;
    public AudioSource audio;

    const float MaxHealth	=  5.0f,	//Amount of time in seconds to change state in absence of events.
                MinPaused   = 10.0f,    //Minimum amount of time a NPC has to remain pausing
                MaxPaused   = 50.0f,    //Maximum amount of time a NPC has to remain pausing
                HealthMargin=  0.7f;    //Percentage of own energy has the player in order to decide if hide away or attack

    PerSeg  PSScript;       //Perímetro de Seguridad script
    Move    PlayerScript;   //Player script Move
    
    GameObject  PS,     //Perímetro de Seguridad
                Player;

    public States	State;
    const float     MinRunningTime = 15.0f;	//Amount of time in seconds to stop running in absence of events.
    public float    Health;

    Clock    AlarmClock,
             WaitingClock;

	// Use this for initialization
	void Start () {
        State       = States.PAUSADO; //Máquina de estados arranca con el estado inicial
		Health      = MaxHealth;

        rb      = GetComponent<Rigidbody>();
        audio   = GetComponent<AudioSource>();

        AlarmClock   = new Clock();
        WaitingClock = new Clock();

        AlarmClock.Start();
        WaitingClock.Start();
        WaitingClock.SetAlarm(0.25f); //Time to wait until a new print can be printed on the console output. 4 times per second

        Player       = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<Move>(); 
        
        PS          = GameObject.Find("PerimetroSeg");
        PSScript    = PS.GetComponent<PerSeg>();
	}

    /**
    float PausingAmount()
    Calculates the time to be pausing. The time to remain in the PAUSED state
    Amount of time awaiting paused before starting to run
    */
    float PausingAmount()
    {
        return  Random.Range(MinPaused,MaxPaused);
    }

    //Timing functions

    /**
    void RunningTimeOut()
    Sets the time to be running on the alarm clock
    */
	void StartRunningTimeOut()
	{
        AlarmClock.SetAlarm(MinRunningTime);
        AlarmClock.StartAlarm();
	}

    /**
    void StartPausingTimeOut()
    Sets the time to be waiting on the alarm clock
    */
    void StartPausingTimeOut()
    {
        AlarmClock.SetAlarm(PausingAmount());
        AlarmClock.StartAlarm();
    }

    void ChangeState(States NewS)
    {
        if (States.MORIR == State) return;

        switch (NewS)
        {
            case States.PAUSADO:
                StartPausingTimeOut();
                break;
            case States.HUIR:
            case States.CORRER:
                StartRunningTimeOut();
                break;
        }

        State = NewS;
    }

    void Print(string S)
    {
        if (WaitingClock.TimeOut())
        {
            WaitingClock.StartAlarm();
            print(S);
        }
    }

    //State methods
    void Saltar()
    {	//Realiza un salto por encima del objeto colisionado
        print("Saltar");
	}

    void SaltarCorrer()
    {	//Realiza un salto por encima del objeto colisionado
        Print("SaltarCorrer");
    }

	void Correr()
    {	//Realiza una carrera
        Print("Correr");
    }

	void Matar(){	//Mata al enemigo
        Print("Matar");
    }

	void Morir(){	//Muere por alcance del jugador
        Print("Morir");
    }

    void Pausar()
    {	//Descansar
       Print("Pausar");
    }

    void SaltarHuir()
    {	//Realiza un salto por encima del objeto colisionado
        Print("SaltarHuir");
    }

    void Huir()
    {	//Realiza un salto por encima del objeto colisionado
        Print("Huir");
    }

	void OnCollisionEnter(Collision collision)
	{
        if (States.MORIR == State) return;
        if (Player.name == collision.contacts[0].otherCollider.gameObject.name)
            State = States.MORIR;
        else if (States.CORRER == State)
             State = States.SALTAR_CORRER;
        else if (States.HUIR == State)
             State = States.SALTAR_HUIR;
	}

    /**
    * @fn public void PlayerNear()
    * What to do when the player enemy is close to the NPC. It touches the security perimeter
    * By default it is suppossed that the NPC has to go to states HUIR or MATAR
    */
    public void PlayerNear()
    {
        if (States.MORIR == State) return;

        if (PlayerScript.Health >= Health * HealthMargin)
             ChangeState(States.HUIR);
        else State = States.MATAR;
    }

    /**
    * @fn public void PlayerGone()
    * What to do when the player enemy has gone. It does not touch the security perimeter
    * By default it is suppossed that the NPC is in states HUIR or MATAR
    */
    public void PlayerGone()
    {
        if (States.MORIR == State) return;
        //Player not collided to the security perimeter. Player gone
        if (AlarmClock.TimeOut())
            ChangeState(States.PAUSADO);
        else if (States.HUIR == State) 
                State = States.CORRER;
        else if (States.MATAR == State)
                ChangeState(States.PAUSADO);
    }

	// Update is called once per frame
	void Update () {
        
		switch (State)
		{
		case States.PAUSADO:
                if (AlarmClock.TimeOut())
                    ChangeState(States.CORRER);
                else Pausar();
			break;
		case States.HUIR:
            Huir();
            if (PlayerScript.Health < Health * HealthMargin)
                State = States.MATAR;
			break;
		case States.SALTAR_HUIR:
			SaltarHuir();
            State = States.HUIR;
            break;
		case States.CORRER:
            if (AlarmClock.TimeOut())
                ChangeState(States.PAUSADO);
            else Correr();
            break;
		case States.SALTAR_CORRER:
			SaltarCorrer();
            State = States.CORRER;
            break;
		case States.MATAR:
			Matar ();
            if (PlayerScript.Health <= 0.0f)
                //Player killed
                ChangeState(States.PAUSADO);
            if (PlayerScript.Health >= Health * HealthMargin)
                State = States.HUIR;
			break;
		case States.MORIR:
			Morir();
            break;
		default:
            break;
		}
	}

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            audio.Play();
        }
    }
}
