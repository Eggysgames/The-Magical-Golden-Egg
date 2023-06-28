using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {


    private MyStaticClass MyStaticClasscode;
    private Main maincode;

    private GameObject UI;
    private GameObject pausemenu;
    private GameObject endinglevel;
    private GameObject endinggame;
    private GameObject deathmenu;
    private GameObject blackbackmainObject;
    private GameObject blackbackmainImage;
    private GameObject deadchicken;
    private GameObject eggicon;

    public bool paused;
    public bool backgroundeffects;
    public bool soundeffects;
    public bool fullscreen;
    public bool startendingfade;
    public bool startendinggamefade;
    public bool startdeathfade;
    public bool startfade;
    public bool scenenext;
    public bool reloadscenefadeout;


    private Text backgroundtext;
    private Text soundtext;
    private Text fullscreentext;
    private Text Levelcompletetext;
    private Text Levelcompletetext2;
    private Text Levelcompletetext3;

    private Text Deathtext;
    private Text Deathtext2;
    private Text Deathtext3;
    private Text gamecompletetext;
    private Text gamecompletetext2;
    private Text gamecompletetext3;
    private Text gamecompletetext4;

    public Text eggscollected;
    public Text eggscollectedend;

    public float fadenumber;
    private string GrabSceneName;

    private GameObject Background;
    private GameObject backgroundeffect;
    public AudioClip cursorsound;
    private AudioSource soundplayer;

    private int roll;

    void Start() {

        GrabSceneName = SceneManager.GetActiveScene().name;
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        UI = GameObject.Find("UI");
        backgroundeffect = GameObject.Find("Weather").gameObject;

        pausemenu = UI.transform.Find("PauseMenu").gameObject;
        deathmenu = UI.transform.Find("DeathMenu").gameObject;
        endinglevel = UI.transform.Find("EndingMenu").gameObject;
        blackbackmainObject = UI.transform.Find("BlackFadeOutHolder").gameObject;

        blackbackmainImage = blackbackmainObject.transform.Find("BlackFadeoutObject").gameObject;
        deadchicken = deathmenu.transform.Find("DeadChicken").gameObject;
        eggicon = endinglevel.transform.Find("EggIcon").gameObject;


        backgroundtext = pausemenu.transform.Find("BackgroundEffectsOnOff").GetComponent<Text>();
        soundtext = pausemenu.transform.Find("SoundOnOff").GetComponent<Text>();
        fullscreentext = pausemenu.transform.Find("FullScreenOnOff").GetComponent<Text>();
        Levelcompletetext = endinglevel.transform.Find("Level Complete").GetComponent<Text>();
        Levelcompletetext2 = endinglevel.transform.Find("EggsCollected").GetComponent<Text>();
        Levelcompletetext3 = endinglevel.transform.Find("Next level").GetComponent<Text>();

        Deathtext = deathmenu.transform.Find("You Died").GetComponent<Text>();
        Deathtext2 = deathmenu.transform.Find("You are Trash").GetComponent<Text>();
        Deathtext3 = deathmenu.transform.Find("Try Again").GetComponent<Text>();

        eggscollected = GameObject.Find("EggsText").GetComponent<Text>();

        //soundplayer = GameObject.Find("Don't Destroy").GetComponent<AudioSource>();
        soundplayer = this.GetComponent<AudioSource>();

        ///////////////
        scenenext = false;
        reloadscenefadeout = false;
        startfade = true;
        fadenumber = 1;
        paused = false;
        backgroundeffects = false;
        soundeffects = true;
        fullscreen = false;
        startendingfade = false;
        startdeathfade = false;
        blackbackmainObject.SetActive(true);

        if (GrabSceneName == "Level 30") {
            endinggame = UI.transform.Find("FinalEndingMenu").gameObject;
            gamecompletetext = endinggame.transform.Find("Game Complete1").GetComponent<Text>();
            gamecompletetext2 = endinggame.transform.Find("EggsCollectedend").GetComponent<Text>();
            gamecompletetext3 = endinggame.transform.Find("Back to Menu3").GetComponent<Text>();
            gamecompletetext4 = endinggame.transform.Find("EndingText4").GetComponent<Text>();
            eggicon = endinggame.transform.Find("EggIcon5").gameObject;
            eggscollectedend = endinggame.transform.Find("EggsCollectedend").GetComponent<Text>();
        }


        if (MyStaticClass.soundholder == false) {
            soundtext.text = "Sound - Off";
            AudioListener.volume = MyStaticClass.soundholdervolume;
            soundeffects = false;
        }
        if (MyStaticClass.soundholder == true) {
            soundtext.text = "Sound - On";
            AudioListener.volume = MyStaticClass.soundholdervolume;
            soundeffects = true;
        }

        if (MyStaticClass.backgroundeffectsholder == false) {
            backgroundtext.text = "Background Effects - Off";
            backgroundtext.text = "Background Effects - Off";
            backgroundeffect.SetActive(false);
            backgroundeffects = false;
        }

        if (MyStaticClass.backgroundeffectsholder == true) {
            backgroundtext.text = "Background Effects - On";
            backgroundeffect.SetActive(true);
            backgroundeffects = true;
        }

        EndingText();

    }


    void Update() {

        if (startfade == true) {
            fadenumber -= 1f * Time.deltaTime;
            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
            if (fadenumber <= 0) {
                startfade = false;
                fadenumber = 0;
            }
        }
        //Fades in End Level Screen
        if (startendingfade == true) {

            if (fadenumber < 0.9) {

                fadenumber += 1f * Time.deltaTime;
                blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
                Levelcompletetext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                Levelcompletetext2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                Levelcompletetext3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                eggicon.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
            }
            if (fadenumber >= 0.9) {
                Levelcompletetext3.GetComponent<Button>().interactable = true;
                //GameDistribution.Instance.ShowAd();

            }
        }
        //Fades in End Game Screen
        if (startendinggamefade == true) {

            if (fadenumber < 0.9) {

                fadenumber += 1f * Time.deltaTime;
                blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
                gamecompletetext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                gamecompletetext2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                gamecompletetext3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                gamecompletetext4.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                eggicon.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
            }
            if (fadenumber >= 0.9) {
                //GameDistribution.Instance.ShowAd();
                gamecompletetext3.GetComponent<Button>().interactable = true;
            }
        }
        //Fades in Death Screen
        if (startdeathfade == true) {

            if (fadenumber < 0.7) {

                fadenumber += 1f * Time.deltaTime;
                blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
                Deathtext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                Deathtext2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                Deathtext3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber);
                deadchicken.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
            }
        }

        if (reloadscenefadeout == true) {
            fadenumber += 1f * Time.deltaTime;
            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);
            deathmenu.SetActive(false);
            if (fadenumber >= 1) {
                if (scenenext == false) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (scenenext == true) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }

        ///Pause Code
        if (Input.GetButtonDown("PauseButton") && paused == false && fadenumber == 0) {
           
            //////////////
            paused = !paused;
            Time.timeScale = 0;
            pausemenu.SetActive(true);
            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(0.7f);
        }
        else if (Input.GetButtonDown("PauseButton") && paused == true && fadenumber == 0) {
           
            /////////////////
            paused = !paused;
            Time.timeScale = 1;
            pausemenu.SetActive(false);
            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(0);
        }
    }

    public void EndtheLevel() {


        //GameDistribution.Instance.ShowAd();



        //////////////////////////////////////
        Levelcompletetext2.text = "Eggs Collected - " + maincode.eggs + "/10";
        Levelcompletetext3.GetComponent<Button>().interactable = false;
        endinglevel.SetActive(true);
        fadenumber = 0;
        startendingfade = true;
        StoreEggData();

    }

    public void EndtheGame() {

        eggscollectedend.text = "Eggs Collected - " + maincode.eggs + "/10";

        gamecompletetext3.GetComponent<Button>().interactable = false;
        endinggame.SetActive(true);
        fadenumber = 0;
        startendinggamefade = true;
        StoreEggData();
    }

    public void DeathFadeout() {




        //////////////////
        deathmenu.SetActive(true);
        fadenumber = 0;
        startdeathfade = true;
    }

    public void unpausegame() {
        ///
        paused = !paused;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(0);
    }

    public void backgroundeffectstoggle() {
        backgroundeffects = !backgroundeffects;
        if (backgroundeffects == false) {
            backgroundtext.text = "Background Effects - Off";
            backgroundeffect.SetActive(false);
            MyStaticClass.backgroundeffectsholder = false;

        }

        if (backgroundeffects == true) {
            backgroundtext.text = "Background Effects - On";
            backgroundeffect.SetActive(true);
            MyStaticClass.backgroundeffectsholder = true;
        }
    }

    public void soundeffectstoggle() {
        soundeffects = !soundeffects;
        if (soundeffects == false) {
            soundtext.text = "Sound - Off";
            MyStaticClass.soundholdervolume = 0;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            maincode.sound = false;
            MyStaticClass.soundholder = false;
        }
        if (soundeffects == true) {
            soundtext.text = "Sound - On";
            MyStaticClass.soundholdervolume = 1;
            AudioListener.volume = MyStaticClass.soundholdervolume;
            maincode.sound = true;
            MyStaticClass.soundholder = true;
        }
    }

    public void fullscreentoggle() {
        fullscreen = !fullscreen;
        if (fullscreen == false) {
            fullscreentext.text = "Fullscreen - Off";
            Time.timeScale = 1;
            Screen.fullScreen = false;
            Time.timeScale = 0;
        }
        if (fullscreen == true) {
            fullscreentext.text = "Fullscreen - On";
            Time.timeScale = 1;
            Screen.fullScreen = true;
            Time.timeScale = 0;
        }
    }
    public void backtomenu() {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("0_Main Menu");
        //Debug.Log("Change Menu");
       
    }

    public void reloadscene() {
        reloadscenefadeout = true;
        scenenext = false;
    }

    public void gotonextlevel() {
        /////

        reloadscenefadeout = true;
        scenenext = true;
        endinglevel.SetActive(false);
    }

    public void StoreEggData() {
        if (GrabSceneName == "Level 1") {
            PlayerPrefs.SetInt("Level2unlocked", 1);
            if (PlayerPrefs.GetInt("Level1CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level1CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 2") {
            PlayerPrefs.SetInt("Level3unlocked", 1);
            if (PlayerPrefs.GetInt("Level2CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level2CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 3") {
            PlayerPrefs.SetInt("Level4unlocked", 1);
            if (PlayerPrefs.GetInt("Level3CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level3CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 4") {
            PlayerPrefs.SetInt("Level5unlocked", 1);
            if (PlayerPrefs.GetInt("Level4CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level4CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 5") {
            PlayerPrefs.SetInt("Level6unlocked", 1);
            if (PlayerPrefs.GetInt("Level5CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level5CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 6") {
            PlayerPrefs.SetInt("Level7unlocked", 1);
            if (PlayerPrefs.GetInt("Level6CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level6CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 7") {
            PlayerPrefs.SetInt("Level8unlocked", 1);
            if (PlayerPrefs.GetInt("Level7CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level7CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 8") {
            PlayerPrefs.SetInt("Level9unlocked", 1);
            if (PlayerPrefs.GetInt("Level8CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level8CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 9") {
            PlayerPrefs.SetInt("Level10unlocked", 1);
            if (PlayerPrefs.GetInt("Level9CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level9CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 10") {
            PlayerPrefs.SetInt("Level11unlocked", 1);
            if (PlayerPrefs.GetInt("Level10CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level10CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 11") {
            PlayerPrefs.SetInt("Level12unlocked", 1);
            if (PlayerPrefs.GetInt("Level11CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level11CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 12") {
            PlayerPrefs.SetInt("Level13unlocked", 1);
            if (PlayerPrefs.GetInt("Level12CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level12CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 13") {
            PlayerPrefs.SetInt("Level14unlocked", 1);
            if (PlayerPrefs.GetInt("Level13CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level13CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 14") {
            PlayerPrefs.SetInt("Level15unlocked", 1);
            if (PlayerPrefs.GetInt("Level14CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level14CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 15") {
            PlayerPrefs.SetInt("Level16unlocked", 1);
            if (PlayerPrefs.GetInt("Level15CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level15CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 16") {
            PlayerPrefs.SetInt("Level17unlocked", 1);
            if (PlayerPrefs.GetInt("Level16CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level16CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 17") {
            PlayerPrefs.SetInt("Level18unlocked", 1);
            if (PlayerPrefs.GetInt("Level17CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level17CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 18") {
            PlayerPrefs.SetInt("Level19unlocked", 1);
            if (PlayerPrefs.GetInt("Level18CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level18CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 19") {
            PlayerPrefs.SetInt("Level20unlocked", 1);
            if (PlayerPrefs.GetInt("Level19CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level19CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 20") {
            PlayerPrefs.SetInt("Level21unlocked", 1);
            if (PlayerPrefs.GetInt("Level20CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level20CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 21") {
            PlayerPrefs.SetInt("Level22unlocked", 1);
            if (PlayerPrefs.GetInt("Level21CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level21CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 22") {
            PlayerPrefs.SetInt("Level23unlocked", 1);
            if (PlayerPrefs.GetInt("Level22CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level22CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 23") {
            PlayerPrefs.SetInt("Level24unlocked", 1);
            if (PlayerPrefs.GetInt("Level23CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level23CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 24") {
            PlayerPrefs.SetInt("Level25unlocked", 1);
            if (PlayerPrefs.GetInt("Level24CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level24CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 25") {
            PlayerPrefs.SetInt("Level26unlocked", 1);
            if (PlayerPrefs.GetInt("Level25CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level25CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 26") {
            PlayerPrefs.SetInt("Level27unlocked", 1);
            if (PlayerPrefs.GetInt("Level26CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level26CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 27") {
            PlayerPrefs.SetInt("Level28unlocked", 1);
            if (PlayerPrefs.GetInt("Level27CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level27CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 28") {
            PlayerPrefs.SetInt("Level29unlocked", 1);
            if (PlayerPrefs.GetInt("Level28CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level28CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 29") {
            PlayerPrefs.SetInt("Level30unlocked", 1);
            if (PlayerPrefs.GetInt("Level29CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level29CollectedEggs", maincode.eggs);
            }
        }
        if (GrabSceneName == "Level 30") {
            //PlayerPrefs.SetInt("Level31unlocked", 1);
            if (PlayerPrefs.GetInt("Level30CollectedEggs") <= maincode.eggs) {
                PlayerPrefs.SetInt("Level30CollectedEggs", maincode.eggs);
            }
        }

    }

    public void SoundSelectPauseMenu() {

        soundplayer.clip = cursorsound;
        soundplayer.Play();

    }

    public void EndingText() {

        roll = Random.Range(1, 25);


        if (roll == 1) {
            Deathtext2.text = "Looks like KFC has come to collect.";
        }
        if (roll == 2) {
            Deathtext2.text = "You're not having a good clucking time are you?";
        }
        if (roll == 3) {
            Deathtext2.text = "Bagawk Bagawk. That means you suck in chicken.";
        }
        if (roll == 4) {
            Deathtext2.text = "You have so much to live for Marshall. Don't give up... You are the chosen one.";
        }
        if (roll == 5) {
            Deathtext2.text = "Knock Knock Neo, you are living in a chicken simulation.";
        }
        if (roll == 6) {
            Deathtext2.text = "Looks like the egg comes before the chicken.";
        }
        if (roll == 7) {
            Deathtext2.text = "So much blood. So much pain. So much suffering. You poor poor chicken.";
        }
        if (roll == 8) {
            Deathtext2.text = "You died again? oh man this is getting rough to watch.";
        }
        if (roll == 9) {
            Deathtext2.text = "Chickens can't fly didn't you know that.";
        }
        if (roll == 10) {
            Deathtext2.text = "You are on your way to chicken heaven. Press try again to stay in this reality.";
        }
        if (roll == 11) {
            Deathtext2.text = "YOU WERE SUCH A GOOD CHICKEN AND NOW YOU ARE JUST TASTY FOOD.";
        }
        if (roll == 12) {
            Deathtext2.text = "Has you story come to and end? or will you try again? haha it rhymes.";
        }
        if (roll == 13) {
            Deathtext2.text = "One small cluck for a chicken, one giant leap for mankind.";
        }
        if (roll == 14) {
            Deathtext2.text = "It's okay try again. And again. And Again. AND. AGAIN!";
        }
        if (roll == 15) {
            Deathtext2.text = "Cluck...clu....cl......arghughghh.";
        }
        if (roll == 16) {
            Deathtext2.text = "Was that your last cluck?";
        }
        if (roll == 17) {
            Deathtext2.text = "It isn't your time yet. You still have more adventures to go.";
        }
        if (roll == 18) {
            Deathtext2.text = "Many many chickens were harmed in the making of this game.";
        }
        if (roll == 19) {
            Deathtext2.text = "You must decide if you want to be food or be the hunter.";
        }
        if (roll == 20) {
            Deathtext2.text = "As you slowly lift your wing...you swear revenge on all that wronged you.";
        }
        if (roll == 21) {
            Deathtext2.text = "Vets say dying is bad for chickens health.";
        }
        if (roll == 22) {
            Deathtext2.text = "This game is dedicated to our chickens, Duke, Polly, Betty and Gretchen.";
        }
        if (roll == 23) {
            Deathtext2.text = "You may have died. But your anger about dying will live on much longer.";
        }
        if (roll == 24) {
            Deathtext2.text = "You died too early my friend. You were meant to live on and save the world.";
        }
        if (roll == 25) {
            Deathtext2.text = "Marshall is getting seriously angry now. Time to get vengeance.";
        }
    }



   
    
}
