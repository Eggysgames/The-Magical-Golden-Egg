using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metalbox : MonoBehaviour {

    public GameObject explosion;
    public AudioClip soundeffect;

    public void Explode() {
        Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Rocket") {
            //AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.2f);
            Explode();
        }
        
    }
}
