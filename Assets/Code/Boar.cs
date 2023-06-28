using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : MonoBehaviour {

    public Rigidbody2D thisRigidbody;
    private EnemyHitPoint enemyhitpointcode;

    public int speed;
    private bool mydirection;
    private Vector3 PiecesXY;
    public int health;

    public GameObject smokepuff;

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public AudioClip soundeffect;

    void Start() {

        thisRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        enemyhitpointcode = this.transform.Find("Hitter").GetComponent<EnemyHitPoint>();
        ////
        speed = 1;
        mydirection = false;
        health = 4;
        enemyhitpointcode.ready = true;
        enemyhitpointcode.ready2 = true;

       
    }


    void Update() {

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x < 1.1) {

            if (health < 0) {
                Death();
            }

            if (mydirection) {
                thisRigidbody.velocity = new Vector2(1 * speed, thisRigidbody.velocity.y);
            }

            if (!mydirection) {
                thisRigidbody.velocity = new Vector2(-1 * speed, thisRigidbody.velocity.y);
            }


        }
    }

    void Death() {

        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.4f);

        PiecesXY = this.gameObject.transform.position;

        Instantiate(smokepuff, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

        Instantiate(piece1, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y + 0.7f), this.gameObject.transform.rotation);
        Instantiate(piece2, new Vector2(PiecesXY.x - 1.4f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece3, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece4, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

        Destroy(gameObject);

    }





}
