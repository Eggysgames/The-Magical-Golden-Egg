using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour {

    public Light myLight;

    private float mytimer;
    private bool mytimerswitch;
    
    void Start() {
        mytimer = 1;
        mytimerswitch = false;
    }


    void Update() {

        if (mytimerswitch == false) {
            mytimer += 0.002f;
        }
        if (mytimerswitch == true) {
            mytimer -= 0.002f;
        }


        if (mytimer >= 1.5) {
            mytimerswitch = true;
        }
        if (mytimer <= 0.5) {
            mytimerswitch = false;
        }

        myLight.intensity = mytimer;

        //myLight.intensity = Mathf.PingPong(Time.time, 1);


    }
}
