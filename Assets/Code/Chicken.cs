using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour {

    private Camera mycamera;

    private Chicken chickencode;
    public Main maincode;
    public Skeleton skeletoncode;
    public Archer archercode;
    public Boar boarcode;
    public Mage magecode;
    public Spirit spiritcode;
    public TNT tntcode;
    public Switch switchcode;
    public Bubble bubblecode;

    public Rigidbody2D ChickenRB;
    public int speed;

    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject MuzzleFlash;
    public GameObject Ricochet;
    public GameObject RicochetRed;
    public GameObject Decal;
    public GameObject holder;
    public GameObject spirit;
    public GameObject smokepuff;

    private Animator BarettaAnimator;

    private Vector3 PiecesXY;
    private Vector3 ChickenXY;
    private bool mydirection;
    private bool gunenabled;
    private int soundroll;

    public GameObject BarettaSprite;
    public Transform Testfire;

    private LineRenderer laserLine;

    public Vector3 vec1;
    public Vector3 vec2;

    public LayerMask mylayermask;
    private Vector3 offset;

    private float gunshootingtimer;

    public Vector3 cameraXpos;
    private float Xholder;
    private float difference;

    public AudioSource soundplayer;
    
    public AudioClip chickensound1;
    public AudioClip chickensound2;
    public AudioClip chickensound3;
    public AudioClip soundeffect;
    public AudioClip switchsoundeffect;

    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip returnsound;
    public AudioClip firesound;
    public AudioClip deathsound;
    public AudioClip deathsound2;
    public AudioClip deathsound3;
    private bool dying;

    private bool shootonce;

    void Start() {

        soundroll = 1;
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        BarettaAnimator = this.transform.Find("G1Baretta").GetComponent<Animator>();
        Testfire = this.transform.Find("Testfire");
        laserLine = GameObject.Find("MyCamera").GetComponent<LineRenderer>();
        ///////
        speed = Random.Range(2, 5);
        vec1 = new Vector3(5, 5, 0);
        mycamera = Camera.main;
        //////////////////
        gunenabled = true;
        mydirection = true;

    }



    void Update() {
        ReturnSpell();
        ////

        float camheight = Camera.main.orthographicSize * 2f;
        float camwidth = camheight * Camera.main.aspect;
        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (mydirection == true) {
            Xholder = mycamera.transform.position.x + camwidth + 1;
            difference = Mathf.Abs(this.transform.position.x - Xholder);
        }
        if (mydirection == false) {
            Xholder = mycamera.transform.position.x - camwidth + 1;
            difference = Mathf.Abs(this.transform.position.x - Xholder);
        }

        //Difference is the distance between the edge of camera and chicken

        //Collide side of camera right
        if (RelativeCameraPosition.x >= 1 && mydirection == true) {
            //Debug.Log("Hit Right");
            mydirection = !mydirection;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        if (RelativeCameraPosition.x < 0) {
            Chickendeath2();
        }
        if (RelativeCameraPosition.y < 0) {
            Chickendeath2();
        }

        if (mydirection) {
            ChickenRB.velocity = new Vector2(1 * speed, ChickenRB.velocity.y);
        }
        if (!mydirection) {
            ChickenRB.velocity = new Vector2(-1 * speed, ChickenRB.velocity.y);
        }


        if (gunenabled) {

            gunshootingtimer += 1f * Time.deltaTime;

            //Debug.Log(gunshootingtimer);

            if (!mydirection) {
                offset = transform.right;
                offset.x += Random.Range(-18, -19);
            }
            if (mydirection) {
                offset = transform.right;
                offset.x += Random.Range(18, 19);
            }

            offset.y += Random.Range(-1, 5);
            offset.z = 0.01f;


            ///My Layer mask is what it can hit
            RaycastHit2D[] hitall = Physics2D.RaycastAll(Testfire.position, offset, difference, mylayermask);


            if (gunshootingtimer >= 1 && hitall.Length > 0 && hitall[0] && shootonce == false) {

                laserLine.enabled = true;
                laserLine.SetPosition(0, Testfire.position);
                laserLine.SetPosition(1, hitall[0].point);

                AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.1f);
                shootonce = true;

                if (BarettaAnimator != null) {
                    BarettaAnimator.SetTrigger("Shoot");
                }



                if (hitall[0].transform.gameObject.tag == "Enemy") {

                    if (hitall[0].collider.GetType() == typeof(CircleCollider2D)) {
                        Instantiate(Ricochet, hitall[0].point, transform.rotation);
                    }
                    if (hitall[0].collider.GetType() == typeof(BoxCollider2D)) {


                        Instantiate(Decal, hitall[0].point, transform.rotation);
                        skeletoncode = hitall[0].transform.gameObject.GetComponent<Skeleton>();
                        skeletoncode.health -= 1;
                        soundroll = Random.Range(1, 3);
                        if (soundroll == 1) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.15f);
                        }
                        if (soundroll == 2) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.2f);
                        }
                        if (soundroll == 3) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.25f);
                        }
                    }

                }

                else if (hitall[0].transform.gameObject.tag == "BoarEnemy") {

                    if (hitall[0].collider.GetType() == typeof(BoxCollider2D)) {
                        Instantiate(Decal, hitall[0].point, transform.rotation);
                        boarcode = hitall[0].transform.gameObject.GetComponent<Boar>();
                        boarcode.health -= 1;

                        soundroll = Random.Range(1, 3);

                        if (soundroll == 1) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.15f);
                        }
                        if (soundroll == 2) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.2f);
                        }
                        if (soundroll == 3) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.25f);
                        }

                    }

                }

                else if (hitall[0].transform.gameObject.tag == "ArcherEnemy") {

                    if (hitall[0].collider.GetType() == typeof(BoxCollider2D)) {
                        Instantiate(Decal, hitall[0].point, transform.rotation);
                        archercode = hitall[0].transform.gameObject.GetComponent<Archer>();
                        archercode.health -= 1;
                        soundroll = Random.Range(1, 3);
                        if (soundroll == 1) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.15f);
                        }
                        if (soundroll == 2) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.2f);
                        }
                        if (soundroll == 3) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.25f);
                        }
                    }

                }

                else if (hitall[0].transform.gameObject.tag == "MageEnemy") {

                    if (hitall[0].collider.GetType() == typeof(BoxCollider2D)) {
                        Instantiate(Decal, hitall[0].point, transform.rotation);
                        magecode = hitall[0].transform.gameObject.GetComponent<Mage>();
                        magecode.health -= 1;
                        soundroll = Random.Range(1, 3);
                        if (soundroll == 1) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.15f);
                        }
                        if (soundroll == 2) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.2f);
                        }
                        if (soundroll == 3) {
                            AudioSource.PlayClipAtPoint(hit1, Camera.main.transform.position, 0.25f);
                        }
                    }

                }

                else if (hitall[0].transform.gameObject.tag == "Explosive") {
                    tntcode = hitall[0].transform.gameObject.GetComponent<TNT>();
                    tntcode.Explode();
                }

                else if (hitall[0].transform.gameObject.tag == "Bubble") {
                    Instantiate(Ricochet, hitall[0].point, transform.rotation);
                    bubblecode = hitall[0].transform.gameObject.GetComponent<Bubble>();
                    bubblecode.Pop2();
                }

                else if (hitall[0].transform.gameObject.tag == "Chicken") {
                    //chickencode = hitall[0].transform.gameObject.GetComponent<Chicken>();
                    //chickencode.Chickendeath();
                }

                else {
                    MuzzleFlash.SetActive(true);
                    Instantiate(Ricochet, hitall[0].point, transform.rotation);
                }
            }

            if (gunshootingtimer > 1.05 && shootonce == true) {
                laserLine.enabled = false;
                MuzzleFlash.SetActive(false);
                gunshootingtimer = 0;
                shootonce = false;

            }

            if (this.transform.position.y < -20) {
                Chickendeath();
            }

        }
    }





    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Explosive") {
            Chickendeath();
        }
        if (col.gameObject.tag == "spike") {
            Chickendeath();
            dying = true;
        }
        if (col.gameObject.tag == "Spikeball") {
            Chickendeath();
        }
        if (col.gameObject.tag == "Metalbox") {
            Chickendeath();
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Eggs") {
            maincode.ChickenTextAdd();
        }
        if (col.gameObject.tag == "Spring") {
            //ChickenRB.velocity = new Vector2(ChickenRB.velocity.x, 10);
            ChickenRB.AddForce(new Vector2(0, 500));
        }
        if (col.gameObject.tag == "Gunbox") {
            BarettaSprite.GetComponent<SpriteRenderer>().enabled = true;
            gunenabled = true;
        }
        if (col.gameObject.tag == "Switch") {
            AudioSource.PlayClipAtPoint(switchsoundeffect, Camera.main.transform.position, 0.2f);
            switchcode = col.GetComponent<Switch>();
            switchcode.Switcher();
        }
        if (col.gameObject.tag == "fire") {
            AudioSource.PlayClipAtPoint(firesound, Camera.main.transform.position, 0.2f);
            Chickendeath();
        }
    }


    public void Chickendeath() {
        if (dying == false) {
            PiecesXY = this.gameObject.transform.position;

            soundroll = Random.Range(1, 6);
            if (soundroll == 1) {
                AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, 0.13f);
            }
            if (soundroll == 2) {
                AudioSource.PlayClipAtPoint(deathsound2, Camera.main.transform.position, 0.25f);
            }
            if (soundroll == 3) {
                AudioSource.PlayClipAtPoint(deathsound3, Camera.main.transform.position, 0.13f);
            }
            if (soundroll == 4) {
                AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, 0.09f);
            }
            if (soundroll == 5) {
                AudioSource.PlayClipAtPoint(deathsound3, Camera.main.transform.position, 0.04f);
            }
            Instantiate(piece1, new Vector2(PiecesXY.x + 0.8f, PiecesXY.y + 1), this.gameObject.transform.rotation);
            Instantiate(piece2, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);
            Instantiate(piece3, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);
            Instantiate(piece4, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);

            holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
            holder.GetComponent<Spirit>().backtoegg = true;
            dying = true;
            Destroy(gameObject);
        }

    }
    public void Chickendeath2() {

        soundroll = Random.Range(1, 6);
        if (soundroll == 1) {
            AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, 0.13f);
        }
        if (soundroll == 2) {
            AudioSource.PlayClipAtPoint(deathsound2, Camera.main.transform.position, 0.25f);
        }
        if (soundroll == 3) {
            AudioSource.PlayClipAtPoint(deathsound3, Camera.main.transform.position, 0.13f);
        }
        if (soundroll == 4) {
            AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, 0.09f);
        }
        if (soundroll == 5) {
            AudioSource.PlayClipAtPoint(deathsound3, Camera.main.transform.position, 0.04f);
        }

        PiecesXY = this.gameObject.transform.position;

        holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
        holder.GetComponent<Spirit>().backtoegg = true;

        Destroy(gameObject);

    }

    void ReturnSpell() {
        if (maincode.unlocktheui >= 3) {
            if (Input.GetButtonDown("RSpell")) {

                AudioSource.PlayClipAtPoint(returnsound, Camera.main.transform.position, 0.08f);

                Instantiate(smokepuff, this.gameObject.transform.position, this.gameObject.transform.rotation);
                holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
                holder.GetComponent<Spirit>().backtoegg = true;
                laserLine.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
