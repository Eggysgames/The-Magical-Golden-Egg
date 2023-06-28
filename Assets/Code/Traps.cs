using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour {

    private Rigidbody2D spikes;
    private bool release;

    public GameObject whitechicken;

    void Start() {

        release = false;
        spikes = GetComponent<Rigidbody2D>();
        
    }

    
    void Update() {

        if (whitechicken != null) {

            if (this.gameObject.transform.position.x - whitechicken.transform.position.x <= 1) {
                release = true;
            }
        }


        if (release) {

            spikes.isKinematic = false;

            //this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.01f);

        }
    
        
    }
}
