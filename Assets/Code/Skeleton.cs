using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    private Chicken chickencode;
    private EnemyHitPoint enemyhitpointcode;

    public int speed;
    
    public int walktimer;
    public bool mydirection;
    public Rigidbody2D SkeletonRB;
    private Vector3 PiecesXY;

    public Animator myAnimator;

    public BoxCollider2D BoxCollider;
    public CircleCollider2D CircleCollider;

    public int health;

    public GameObject smokepuff;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public Vector3 RelativeCameraPosition;

    public AudioClip soundeffect1;
    public AudioClip soundeffect2;
    public AudioClip soundeffect3;
    private int soundroll;
    public AudioClip swordsound;

    void Start() {

        health = 9; 
        speed = 1;
        walktimer = 0;
        myAnimator = SkeletonRB.GetComponent<Animator>();
        enemyhitpointcode = this.transform.Find("Hitter").GetComponent<EnemyHitPoint>();

    }



    void Update() {

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x < 1.1) {

            if (health < 0) {
                SkeletonDie();
            }

            if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton Walk Leftsided")) {
                speed = 1;
            }
            if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton Attack Controller")) {
                speed = 0;
            }

            if (mydirection) {
                SkeletonRB.velocity = new Vector2(1 * speed, SkeletonRB.velocity.y);
            }
            if (!mydirection) {
                SkeletonRB.velocity = new Vector2(-1 * speed, SkeletonRB.velocity.y);
            }
        }

    }



       void AnimationTriggerStart() {
            enemyhitpointcode.ready = true;
        }
        void AnimationTriggerStop() {
            enemyhitpointcode.ready = false;
        }

        void AnimationTriggerStart2() {
        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x < 1.1 && RelativeCameraPosition.x >= -0.1) {
            AudioSource.PlayClipAtPoint(swordsound, Camera.main.transform.position, 0.04f);
        }
            enemyhitpointcode.ready2 = true;
        }
        void AnimationTriggerStop2() {
            enemyhitpointcode.ready2 = false;
        }


    void OnCollisionEnter2D(Collision2D col) {

            if (col.otherCollider == BoxCollider) {

                if (col.gameObject.tag == "Ground") {

                    Vector3 hit = col.contacts[0].normal;
                    float angle = Vector3.Angle(hit, Vector3.up);

                    if (Mathf.Approximately(angle, 0)) {
                        //Debug.Log("Hit Down");
                    }
                    if (Mathf.Approximately(angle, 180)) {
                        //Debug.Log("Hit Up");
                    }
                    if (Mathf.Approximately(angle, 90)) {
                        Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                        if (cross.y > 0) {
                            //Debug.Log("Hit Left");
                            mydirection = !mydirection;
                            Vector3 theScale = transform.localScale;
                            theScale.x *= -1;
                            transform.localScale = theScale;
                        }
                        else {
                            //Debug.Log("Hit Right");
                            mydirection = !mydirection;
                            Vector3 theScale = transform.localScale;
                            theScale.x *= -1;
                            transform.localScale = theScale;
                        }
                    }
                }
            }

        }


       void SkeletonDie() {

        soundroll = Random.Range(1, 4);
        

        if (soundroll == 1) {
            AudioSource.PlayClipAtPoint(soundeffect1, Camera.main.transform.position, 0.15f);
        }
        if (soundroll == 2) {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.2f);
        }
        if (soundroll == 3) {
            AudioSource.PlayClipAtPoint(soundeffect3, Camera.main.transform.position, 0.25f);
        }

        PiecesXY = this.gameObject.transform.position;

            Instantiate(smokepuff, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

            Instantiate(piece1, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y + 0.7f), this.gameObject.transform.rotation);
            Instantiate(piece2, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);
            Instantiate(piece3, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);
            Instantiate(piece4, new Vector2(PiecesXY.x - 0.5f, PiecesXY.y), this.gameObject.transform.rotation);

            Destroy(gameObject);

       }
    }

