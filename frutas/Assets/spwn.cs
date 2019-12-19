using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwn : MonoBehaviour
{
    
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject Prefab4;
    private float Timer;
 
    void Start()
    {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        prefabList.Add(Prefab4);
        Timer = Time.time + 2;

    }
 
    void Update()
    {   
        if (Timer < Time.time) { //This checks wether real time has caught up to the timer
            int prefabIndex = UnityEngine.Random.Range(0,4);
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-15,15),25,UnityEngine.Random.Range(-7,7));
            GameObject fruta = (GameObject)Instantiate(prefabList[prefabIndex],pos,transform.rotation);
            Timer = Time.time + 2; //This sets the timer 3 seconds into the future
        }
        
    }

}
