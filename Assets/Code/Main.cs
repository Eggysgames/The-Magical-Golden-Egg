using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Main : MonoBehaviour {

    private Spirit spiritcode;
    private GameObject UI;
    private Rigidbody2D GoldeneggRB;
    private WhiteChicken whitechickencode;

    public GameObject whitechicken;
    public GameObject goldenegg;
    public GameObject chicken;
    public GameObject spirit;
    public GameObject shooteffect;
    private GameObject whitehighlight;
    private GameObject chickensquare;
    private GameObject springsquare;
    private GameObject square3;
    private GameObject square4;
    private GameObject square5;
    private GameObject square6;
    public GameObject shieldeffect;
    public GameObject target;
    public GameObject objectToFollow;
    public GameObject holder;
    public GameObject shieldhitsparks;
    public GameObject shieldhitembers;

    private GameObject temppos;

    private bool runslowerbool;
    private float runslowerint;
    private Vector3 mousePos;
    private Vector3 spawnXY;

    private bool mytrigger = true;

    public int unlocktheui;
    public int whattospawn;
    public int speed;
    public int eggs;
    public int chickensremaining;

    public bool whichside;
    public bool sound;
    public bool endlevel;
    public bool startlevel;
    public bool reloading;

    private Image fader;
    private GameObject faderobject;
    public float countdown;
    private string GrabSceneName;

    private Text eggscollected;
    private TextMeshProUGUI chickensremainingtext;

    

    public GameObject rocket;
    public int level1eggscollectedbest;

    private GameObject lock1;
    private GameObject lock2;
    private GameObject lock3;

    private void Start() {

        
        

        //Application.targetFrameRate = 200;
        whitechickencode = whitechicken.GetComponent<WhiteChicken>();
        GrabSceneName = SceneManager.GetActiveScene().name;
        UI = GameObject.Find("UI");
        whitehighlight = GameObject.Find("Highlight");
        chickensquare = GameObject.Find("ChickenSquare");
        springsquare = GameObject.Find("SpringSquare");
        square3 = GameObject.Find("Square3");
        square4 = GameObject.Find("Square4");
        square5 = GameObject.Find("Square5");
        eggscollected = GameObject.Find("EggsText").GetComponent<Text>();
        faderobject = UI.transform.Find("FadeReload").gameObject;
        fader = faderobject.GetComponent<Image>();
        chickensremainingtext = GameObject.Find("RemainingText").GetComponent<TextMeshProUGUI>();
        lock1 = GameObject.Find("LockIcon1");
        lock2 = GameObject.Find("LockIcon2");
        lock3 = GameObject.Find("LockIcon3");

        if (GrabSceneName == "Level 1") {
            chickensremaining = 0;
            unlocktheui = 1;
            startlevel = true;
        }
        if (GrabSceneName == "Level 2") {
            chickensremaining = 5;
            unlocktheui = 2;
            startlevel = false;
            lock1.SetActive(false);
        }
        if (GrabSceneName == "Level 3" || GrabSceneName == "Level 4" || GrabSceneName == "Level 5" || GrabSceneName == "Level 6" || GrabSceneName == "Level 7") {
            chickensremaining = 5;
            unlocktheui = 3;
            startlevel = false;
            lock1.SetActive(false);
            lock2.SetActive(false);
        }

        if (GrabSceneName == "Level 8" || GrabSceneName == "Level 9" || GrabSceneName == "Level 10" || GrabSceneName == "Level 11" || GrabSceneName == "Level 12" || GrabSceneName == "Level 13" || GrabSceneName == "Level 14" || GrabSceneName == "Level 15" || GrabSceneName == "Level 16" || GrabSceneName == "Level 17" || GrabSceneName == "Level 18" || GrabSceneName == "Level 19" || GrabSceneName == "Level 20" || GrabSceneName == "Level 21" || GrabSceneName == "Level 22" || GrabSceneName == "Level 23" || GrabSceneName == "Level 24" || GrabSceneName == "Level 25" || GrabSceneName == "Level 26" || GrabSceneName == "Level 27" || GrabSceneName == "Level 28" || GrabSceneName == "Level 29" || GrabSceneName == "Level 30") {
            chickensremaining = 5;
            unlocktheui = 4;
            startlevel = false;
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
        }
        
        GoldeneggRB = goldenegg.GetComponent<Rigidbody2D>();

        ////
        endlevel = false;
        whattospawn = 1;
        chickensremainingtext.text = chickensremaining.ToString() + "/5";
        countdown = 1;
        runslowerbool = true;
        runslowerint = 100;
        countdown = 0;
        whitehighlight.transform.position = chickensquare.transform.position;


    }
    void Update() {

        mousePos = Input.mousePosition;
        mousePos.z = 28.01f;
        spawnXY = Camera.main.ScreenToWorldPoint(mousePos);
        ////////////
        PressMouse();
        inputkeys();
        Reload();

        if (runslowerbool == false) {
            runslowerint--;
            if (runslowerint < 0) {
                runslowerbool = true;
                runslowerint = 100;
            }
        }

        CameraFollow();

    }



    void PressMouse() {

        if (whitechicken != null && startlevel == true) {

            if (whattospawn != 3 && whattospawn != 4) {

                if (Input.GetMouseButton(0) && mytrigger == true && chickensremaining > 0 && endlevel == false) {

                    if (whattospawn != 5) {
                        ///Spawn a spirit to the mouse
                        Instantiate(shooteffect, goldenegg.transform.position, goldenegg.transform.rotation);
                        holder = Instantiate(spirit, goldenegg.transform.position, this.gameObject.transform.rotation);
                        holder.GetComponent<Spirit>().backtoegg = false;
                        holder.GetComponent<Spirit>().mouseXY = spawnXY;

                        ///Slow it down bro
                        mytrigger = false;
                        chickensremaining -= 1;
                        chickensremainingtext.text = chickensremaining.ToString() + "/5";
                    }
                    if (whattospawn == 5) {
                        
                        Instantiate(shooteffect, goldenegg.transform.position, goldenegg.transform.rotation);
                        holder = Instantiate(rocket, goldenegg.transform.position, this.gameObject.transform.rotation);

                        mytrigger = false;
                        chickensremaining -= 1;
                        chickensremainingtext.text = chickensremaining.ToString() + "/5";
                    }
                }
                if (Input.GetMouseButtonUp(0)) {
                    mytrigger = true;
                }
            }
        }
    }


    void inputkeys() {

        //Disable Input
        //Input.

        if (whitechicken != null && startlevel == true) {

            if (Input.GetButtonDown("ChickenSpell")) {
                whitehighlight.transform.position = new Vector3(chickensquare.transform.position.x - 0.1f, chickensquare.transform.position.y, chickensquare.transform.position.z);
                whattospawn = 1;
            }

            else if (Input.GetButtonDown("SpringSpell")) {
                whitehighlight.transform.position = new Vector3(springsquare.transform.position.x - 0.1f, springsquare.transform.position.y, springsquare.transform.position.z);
                whattospawn = 2;
            }


            else if (Input.GetButtonDown("ESpell")) {
                if (unlocktheui >= 2) {
                    whitehighlight.transform.position = new Vector3(square3.transform.position.x - 0.1f, square3.transform.position.y, square3.transform.position.z);
                    whattospawn = 3;

                    if (!reloading && chickensremaining >= 1) {
                        chickensremaining -= 1;
                        chickensremainingtext.text = chickensremaining.ToString() + "/5";
                        temppos = Instantiate(shieldeffect, whitechicken.transform.position, whitechicken.transform.rotation);
                        faderobject.GetComponent<Image>().enabled = true;
                        reloading = true;
                        countdown = 1;
                        
                    }
                }
            }

            else if (Input.GetButtonDown("RSpell")) {
                if (unlocktheui >= 3) {
                    whitehighlight.transform.position = new Vector3(square4.transform.position.x - 0.1f, square4.transform.position.y, square4.transform.position.z);
                    whattospawn = 4;
                }
            }

            else if (Input.GetButtonDown("TSpell")) {
                if (unlocktheui >= 4) {
                    whitehighlight.transform.position = new Vector3(square5.transform.position.x - 0.1f, square5.transform.position.y, square5.transform.position.z);
                    whattospawn = 5;
                }
            }
            else if (Input.GetButtonDown("YSpell")) {
                if (unlocktheui >= 5) {
                    whitehighlight.transform.position = new Vector3(square6.transform.position.x - 0.1f, square6.transform.position.y, square6.transform.position.z);
                    whattospawn = 6;
                }
            }


        }
    }

    public void Adder() {
        if (whichside == false) {
            GoldeneggRB.AddForce(new Vector2(-500, 0));
        }
        if (whichside == true) {
            GoldeneggRB.AddForce(new Vector2(500, 0));
        }
        chickensremaining += 1;
        chickensremainingtext.text = chickensremaining.ToString() + "/5";
    }

    public void ChickenTextAdd() {
        eggs += 1;
        eggscollected.text = "Eggs - " + eggs + "/10";
    }


    //////////////////
    //////////////////
    void Reload() {
        if (reloading == true) {
            countdown -= 0.4f * Time.deltaTime;
            Vector3 theScale = fader.transform.localScale;
            theScale.y = countdown;
            fader.transform.localScale = theScale;
        }

        if (countdown < 0.01 && reloading == true) {
            
            chickensremaining += 1;
            chickensremainingtext.text = chickensremaining.ToString() + "/5";
            faderobject.GetComponent<Image>().enabled = true;
            reloading = false;
        }
    }

    public void ShieldEffectDisplay() {

        if (temppos != null) {
            if (runslowerbool == true) {
                
                Instantiate(shieldhitsparks, temppos.transform.position, this.gameObject.transform.rotation);
                runslowerbool = false;
            }
        }
    }
    public void ShieldEffectDisplay2() {

        if (temppos != null) {
            if (runslowerbool == true) {
                
                Instantiate(shieldhitembers, temppos.transform.position, this.gameObject.transform.rotation);
                runslowerbool = false;
            }
        }
    }

    public void CameraFollow() {
        if (whitechicken != null) {

            float inter = speed * Time.deltaTime;
            Vector3 position = this.transform.position;
            position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x + 8, inter);
            //position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y, inter);

            ///Edges
            if (position.x < -25) {
                position.x = -25;
            }

            this.transform.position = position;
        }
    }

}