using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WhiteChicken : MonoBehaviour {

    private Main maincode;
    private Menu menucode; 
    private WhiteChicken chickencode;
    public Switch switchcode;

    private Rigidbody2D ChickenRB;
    private Rigidbody2D GoldeneggRB;

    private Animator ChickenAnimator;

    public GameObject GoldenEgg;
    public GameObject Chain1;
    public GameObject Chain2;
    public GameObject Eggeffects;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;

    public float speed;
    private bool mydirection;
    private bool jumponlyonce;
    private Vector3 PiecesXY;
    private Vector3 ChickenXY;
    private int speedtimer;
    private bool fadeinstart;

    private Color mycolour;
    private float colourfade;
    private bool endlevel;
    private string GrabSceneName;
    
    public AudioSource soundplayer;
    public AudioClip chickensound1;
    public AudioClip chickensound2;
    public AudioClip chickensound3;
    public AudioClip springsoundeffect;
    public AudioClip switchsoundeffect;
    public AudioClip firesound;
    public AudioClip deathsound;
    public AudioClip deathsound2;
    public AudioClip deathsound3;
    private int soundroll;
    public AudioClip clicksound;


    void Start() {

        GrabSceneName = SceneManager.GetActiveScene().name;

        GoldeneggRB = GoldenEgg.GetComponent<Rigidbody2D>();
        ChickenRB = this.gameObject.GetComponent<Rigidbody2D>();
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        menucode = GameObject.Find("UI").GetComponent<Menu>();
        mycolour = GetComponent<SpriteRenderer>().color;
        ChickenAnimator = this.gameObject.GetComponent<Animator>();

        if (GrabSceneName == "Level 1") {
            fadeinstart = false;
            mycolour.a = 1f;
            colourfade = 1f;
        }

        if (GrabSceneName != "Level 1") {
            ChickenAnimator.speed = 0;
            fadeinstart = true;
            mycolour.a = 0f;
            colourfade = 0f;
            Eggeffects.SetActive(false);
            GetComponent<SpriteRenderer>().color = mycolour;
            GoldenEgg.GetComponent<SpriteRenderer>().color = mycolour;
            Chain1.GetComponent<SpriteRenderer>().color = mycolour;
            Chain2.GetComponent<SpriteRenderer>().color = mycolour;
        }

        //////////////
        endlevel = false;
        mydirection = true;
        jumponlyonce = false;
        //soundplayer.PlayOneShot(chickensound3, 0.7f);
    }

   

    void Update() {
        SingleRunStart();
        speedrun();
        Fadeout();
        Fadein();
        ///////////////
        //////Movement and Clamping
        ChickenRB.velocity = Vector3.ClampMagnitude(ChickenRB.velocity, 12);

        if (fadeinstart == false) {
            if (mydirection) {
                ChickenRB.velocity = new Vector2(1 * speed, ChickenRB.velocity.y);
            }
            if (!mydirection) {
                ChickenRB.velocity = new Vector2(-1 * speed, ChickenRB.velocity.y);
            }

        }

        if (this.transform.position.y <-9) {
            Chickendeath();
        }

        //Debug.Log(deathchecker);

        
    }

    

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "spike") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }
        if (col.gameObject.tag == "Metalbox") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }
    }


    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "fire") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay2();
            }
            if (maincode.countdown < 0.5) {
                AudioSource.PlayClipAtPoint(firesound, Camera.main.transform.position, 0.2f);
                Chickendeath();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Ending") {
            maincode.endlevel = true;
            endlevel = true;
        }

        if (col.gameObject.tag == "Ending2") {
            maincode.endlevel = true;
            menucode.EndtheGame();
            //Destroy(Chain1);
            ChickenAnimator.speed = 0;

        }


        if (col.gameObject.tag == "EndingAir") {
            speed = 0;
        }
        if (col.gameObject.tag == "Explosive") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }

        if (col.gameObject.tag == "spike") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }

        if (col.gameObject.tag == "Spikeball") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }

        if (col.gameObject.tag == "Metalbox") {
            if (maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (maincode.countdown < 0.5) {
                Chickendeath();
            }
        }


    }



    void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag == "Eggs") {
            maincode.ChickenTextAdd();
        }

        if (col.gameObject.tag == "Spring") {
            
            AudioSource.PlayClipAtPoint(springsoundeffect, Camera.main.transform.position, 0.3f);

            if (speed != 0) {
                if (ChickenRB.velocity.y < 8.3f) {
                    ChickenRB.velocity = Vector2.zero;
                    ChickenRB.AddForce(new Vector2(0, 800));
                }
            }

        }

        if (col.gameObject.tag == "Switch") {
            AudioSource.PlayClipAtPoint(switchsoundeffect, Camera.main.transform.position, 0.2f);
            switchcode = col.GetComponent<Switch>();
            switchcode.Switcher();
        }

        
    }


    public void Chickendeath() {

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

        menucode.DeathFadeout();
        PiecesXY = this.gameObject.transform.position;
        Instantiate(piece1, new Vector2(PiecesXY.x + 0.8f, PiecesXY.y + 1), this.gameObject.transform.rotation);
        Instantiate(piece2, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece3, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);
        Instantiate(piece4, new Vector2(PiecesXY.x, PiecesXY.y), this.gameObject.transform.rotation);

        Destroy(gameObject);

    }

    void Fadein() {
        if (fadeinstart == true) {
            colourfade += 0.5f * Time.deltaTime;
            mycolour.a = colourfade;
            GetComponent<SpriteRenderer>().color = mycolour;
            GoldenEgg.GetComponent<SpriteRenderer>().color = mycolour;
            Chain1.GetComponent<SpriteRenderer>().color = mycolour;
            Chain2.GetComponent<SpriteRenderer>().color = mycolour;
            if (colourfade >= 0.2) {
                Eggeffects.SetActive(true);
            }
            if (colourfade >= 1) {
                ChickenAnimator.speed = 1;
                fadeinstart = false;
                maincode.startlevel = true;
            }
        }
    }

    void Fadeout() {
        if (endlevel == true) {
            
            colourfade -= 1f * Time.deltaTime;
            mycolour.a = colourfade;
            GetComponent<SpriteRenderer>().color = mycolour;
            GoldenEgg.GetComponent<SpriteRenderer>().color = mycolour;
            Chain1.GetComponent<SpriteRenderer>().color = mycolour;
            Chain2.GetComponent<SpriteRenderer>().color = mycolour;
            Vector3 theScale = transform.localScale;
            Eggeffects.SetActive(false);
            if (theScale.x >= 0.1) {
                theScale.x -= 0.5f * Time.deltaTime;
            }
            if (theScale.y >= 0.1) {
                theScale.y -= 0.5f * Time.deltaTime;
            }
            transform.localScale = theScale;
            /////
            if (theScale.x < 0.2) {
                menucode.EndtheLevel();
                Destroy(GoldenEgg);
                Destroy(Chain1);
                Destroy(Chain2);
                Destroy(gameObject);
                ////
            }
        }
    }

    public void SingleRunStart() {
        if (this.transform.position.x >= -27.5 && jumponlyonce == false && GrabSceneName == "Level 1") {
            speed = 2f;
            ChickenRB.AddForce(new Vector2(0, 500));
            jumponlyonce = true;

        }
    }

    public void speedrun() {
        if (jumponlyonce == true && GrabSceneName == "Level 1") {
            speedtimer++;
            if (speedtimer > 160) {
                speed = 1;
            }
        }

    }


    public void Emptysound() {
        AudioSource.PlayClipAtPoint(clicksound, Camera.main.transform.position, 0.13f);
    }
}
