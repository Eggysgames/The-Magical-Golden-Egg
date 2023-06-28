using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour {

    public Rigidbody2D MageRB;
    public Animator myAnimator;
    public GameObject whitechicken;

    public int speed;
    public bool mydirection;

    public int health;

    private Vector3 PiecesXY;

    public GameObject smokepuff;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public GameObject spherespell;

    public GameObject SpawnPos;
    
    private float distancecheck;
    private bool pauseattack;
    public int timer;

    public AudioClip soundeffect1;
    public AudioClip soundeffect2;
    public AudioClip soundeffect3;
    public AudioClip soundeffect4;
    public AudioClip soundeffect5;
    private int soundroll;

    void Start() {

        timer = 0;
        health = 5;
        mydirection = false;
        speed = 0;
        myAnimator = MageRB.GetComponent<Animator>();
        whitechicken = GameObject.Find("WhiteChicken");

    }


    void Update() {

        if (whitechicken != null) { 

        if (whitechicken.transform.position.x > this.transform.position.x) {
            myAnimator.enabled = true;
            myAnimator.SetTrigger("myswitch2");
            speed = 1;
        }
        if (mydirection) {
            MageRB.velocity = new Vector2(1 * speed, MageRB.velocity.y);
        }
        if (!mydirection) {
            MageRB.velocity = new Vector2(-1 * speed, MageRB.velocity.y);
        }
        if (health <= 0) {
            Death();
        }
            ////

            if (whitechicken.transform.position.x < this.transform.position.x) {

                distancecheck = this.transform.position.x - whitechicken.transform.position.x;

                if (distancecheck < 13) {
                    myAnimator.SetTrigger("myswitch");
                }

                if (pauseattack == true) {
                    timer++;
                    if (timer > 200) {
                        myAnimator.enabled = true;
                        pauseattack = false;
                        timer = 0;
                    }
                }


                Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);



                if (RelativeCameraPosition.x < 1 && RelativeCameraPosition.x >= 0) {

                    if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mage Walk Animation")) {
                        speed = 1;
                    }
                    if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Mage Attack Animation")) {
                        speed = 0;
                    }

                }
            }
            }
        }

    void EndAnimation() {
        myAnimator.enabled = false;
        pauseattack = true;
    }


    void AnimationTriggerStart() {
        Shoot();
    }

    void Shoot() {

        Instantiate(spherespell, SpawnPos.transform.position, this.transform.rotation);

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
