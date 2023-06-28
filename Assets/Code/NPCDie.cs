using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDie : MonoBehaviour {

    private Vector3 PiecesXY;
    public GameObject smokepuff;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public AudioClip soundeffect;

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Spikeball") {
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.25f);
            Death();

        }
    }

    void Death() {


        PiecesXY = this.gameObject.transform.position;

        Instantiate(smokepuff, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

        Instantiate(piece1, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y + 0.7f), this.gameObject.transform.rotation);
        Instantiate(piece2, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece3, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece4, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y + 0.1f), this.gameObject.transform.rotation);

        Destroy(gameObject);

    }
}
