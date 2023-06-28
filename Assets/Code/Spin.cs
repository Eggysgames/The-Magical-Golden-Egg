using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public int spunfast;

    void Start() { 

    }

   
    void Update() {

        transform.Rotate(0, 0, spunfast); //rotates 50 degrees per second around z axis
        
    }
}
