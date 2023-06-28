using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public Sprite[] levers;
    public GameObject colliderattached;
    //private bool touched;

    public ParticleSystem firesystem;

    void Start() {
        //touched = false;
        firesystem = firesystem.GetComponent<ParticleSystem>();
    }

   
    void Update() { 
    
        
    }

    public void Switcher() {
        GetComponent<SpriteRenderer>().sprite = levers[1];
        colliderattached.SetActive(false);
        firesystem.Stop(true);
    }


}
