using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour { 

    // Start is called before the first frame update
    void Start() { 
    
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        this.transform.Translate(Vector2.right / 20);

    }
}
