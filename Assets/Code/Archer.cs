using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public GameObject Arrow;
    public GameObject SpawnPos;

    private bool released;
    private int timer;
    private Vector3 PiecesXY;
    public int health;

    public GameObject smokepuff;

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public AudioClip soundeffect1;
    public AudioClip soundeffect2;
    public AudioClip soundeffect3;
    public AudioClip soundeffect4;
    public AudioClip soundeffect5;
    private int soundroll;
    public AudioClip twang1;
    

    void Start() {


        health = 5;

    }

    
    void Update() {

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (health <= 0) {
            Death();
        }
    }


    void AnimationTriggerShoot() {
        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x < 1.1 && RelativeCameraPosition.x >= -0.1) {
            AudioSource.PlayClipAtPoint(twang1, Camera.main.transform.position, 0.1f);
            Instantiate(Arrow, SpawnPos.transform.position, this.transform.rotation);
        }

    }



    void Death() {

        soundroll = Random.Range(1, 6);

        if (soundroll == 1) {
            AudioSource.PlayClipAtPoint(soundeffect1, Camera.main.transform.position, 0.15f);
        }
        if (soundroll == 2) {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.1f);
        }
        if (soundroll == 3) {
            AudioSource.PlayClipAtPoint(soundeffect3, Camera.main.transform.position, 0.15f);
        }
        if (soundroll == 4) {
            AudioSource.PlayClipAtPoint(soundeffect4, Camera.main.transform.position, 0.15f);
        }
        if (soundroll == 5) {
            AudioSource.PlayClipAtPoint(soundeffect5, Camera.main.transform.position, 0.15f);
        }

        PiecesXY = this.gameObject.transform.position;

        Instantiate(smokepuff, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

        Instantiate(piece1, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y + 0.7f), this.gameObject.transform.rotation);
        Instantiate(piece2, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece3, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece4, new Vector2(PiecesXY.x - 0.2f, PiecesXY.y + 0.1f), this.gameObject.transform.rotation);

        Destroy(gameObject);

    }
}
