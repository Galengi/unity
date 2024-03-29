﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    private float Maxhp;
    public float hp = 10f;
    private Transform target;
    private GameObject canvas;
    private Scrollbar vida, vida1;
    private GameObject x;
    private Animator myAnimator;
    void Start()
    {
        target = Camera.main.transform;
        canvas = transform.Find("Canvas").gameObject;
        vida = canvas.transform.Find("Health").GetComponent<Scrollbar>();
        vida1 = canvas.transform.Find("Health1").GetComponent<Scrollbar>();
        Maxhp = hp;
        canvas.SetActive(false);
        myAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Vector3 v = target.position - canvas.transform.position;
        v.Normalize();
        canvas.transform.rotation = Quaternion.LookRotation(new Vector3(v.x, 0, v.z));
    }

    public void getHit(float damage)
    {
        canvas.SetActive(true);
       // if (gameObject.name == "Fuath") {myAnimator.SetTrigger("isHurt");}
        //Animación de recibir daño setTrigger
        hp -= damage;
        Debug.Log("Enemy ouch - " + hp + " hp left");
        if (hp <= 0) Destroy(gameObject);
        vida.size = hp / Maxhp;
        //vida1.size = hp/Maxhp;
    }
}
