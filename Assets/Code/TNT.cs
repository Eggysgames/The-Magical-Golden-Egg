using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour {

    public GameObject explosion;
    public AudioClip explosionsound;


    public void Explode() {

        AudioSource.PlayClipAtPoint(explosionsound, Camera.main.transform.position, 0.4f);

        Instantiate(explosion, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "WhiteChicken") {
            Explode();
        }
        if (col.gameObject.tag == "Chicken") {
            Explode();
        }
    }
}
