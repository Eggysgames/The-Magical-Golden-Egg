using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

    public GameObject puff;
    public AudioClip soundeffect;


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Chicken") {
            Instantiate(puff, this.gameObject.transform.position, this.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.08f);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "WhiteChicken") {
            Instantiate(puff, this.gameObject.transform.position, this.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.08f);
            Destroy(gameObject);
        }
    }
}
