using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

    public GameObject WhiteChicken;
    private Transform target;
    private Vector3 PiecesXY;
    public GameObject richochet;

    public AudioClip soundeffect1;
    public AudioClip soundeffect2;

    void Start() {

        WhiteChicken = GameObject.Find("WhiteChicken");

        if (WhiteChicken != null) {
            target = WhiteChicken.transform;
            AudioSource.PlayClipAtPoint(soundeffect1, Camera.main.transform.position, 0.1f);
        }

    }



        void Update() {

        if (target != null) {
            this.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, Time.deltaTime * 2);
        }
    }


    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Chicken") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.3f);
            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y), this.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "WhiteChicken") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.3f);
            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y), this.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ground") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.3f);
            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x, PiecesXY.y), this.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Shield") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.3f);

            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y), this.transform.rotation);
            Destroy(gameObject);
        }

    }


}
