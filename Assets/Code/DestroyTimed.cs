using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimed : MonoBehaviour {

    public int removetimer; 
    
    void Start() { 
    
        
    }

    
    void Update() {

        removetimer -= 1;

        if (removetimer <= 0) {
            Destroy(gameObject); 
        }

    }
}
