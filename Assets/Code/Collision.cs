using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour { 

    
    void Start() {
        ///Debug.Log("Start code");
    }


    void Update() { }
    


        
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Coins") {
            //Debug.Log("Brad hit Coins");
        }

        ///Not triggering
        if (col.gameObject.tag == "Heads") {
            //Debug.Log("Brad hit Marty");
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log("Marty hit Bradley Trigger");
    }


}

