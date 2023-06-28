using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour {

    public Rigidbody2D pieces;
    public int forcerollX;
    public int forcerollY;
    public Vector2 impulseMagnitude;

    void Start() {
        pieces = GetComponent<Rigidbody2D>();
        
        forcerollX = Random.Range(1, 10);
        forcerollY = Random.Range(-15, 15);

        impulseMagnitude = new Vector2(forcerollX, forcerollY);

        ForceFunction();
    }

    private void ForceFunction() {
        pieces.AddForce(impulseMagnitude, ForceMode2D.Impulse);
    }

}

