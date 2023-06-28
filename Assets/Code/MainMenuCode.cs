using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuCode : MonoBehaviour {

    private MyStaticClass MyStaticClasscode;

    public GameObject thecamera;

    private bool startfade;
    private float fadenumber;
    private float fadenumber2;
    public GameObject blackbackmainImage;
    public GameObject blackback;

    public Text titletext;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;

    public Text Level1;
    public Text Level2;
    public Text Level3;
    public Text Level4;
    public Text Level5;
    public Text Level6;
    public Text Level7;
    public Text Level8;
    public Text Level9;
    public Text Level10;
    public Text Level11;
    public Text Level12;
    public Text Level13;
    public Text Level14;
    public Text Level15;
    public Text Level16;
    public Text Level17;
    public Text Level18;
    public Text Level19;
    public Text Level20;
    public Text Level21;
    public Text Level22;
    public Text Level23;
    public Text Level24;
    public Text Level25;
    public Text Level26;
    public Text Level27;
    public Text Level28;
    public Text Level29;
    public Text Level30;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;
    public GameObject lock6;
    public GameObject lock7;
    public GameObject lock8;
    public GameObject lock9;
    public GameObject lock10;
    public GameObject lock11;
    public GameObject lock12;
    public GameObject lock13;
    public GameObject lock14;
    public GameObject lock15;
    public GameObject lock16;
    public GameObject lock17;
    public GameObject lock18;
    public GameObject lock19;
    public GameObject lock20;
    public GameObject lock21;
    public GameObject lock22;
    public GameObject lock23;
    public GameObject lock24;
    public GameObject lock25;
    public GameObject lock26;
    public GameObject lock27;
    public GameObject lock28;
    public GameObject lock29;

    private bool changelevelfade;
    private string thescenename;
    private string GrabSceneName;

    public AudioClip cursorsound;


    void Start() {


        //GameDistribution.Instance.ShowAd();


        if (MyStaticClass.soundholder == true) {
            AudioListener.volume = MyStaticClass.soundholdervolume;
        }
        if (MyStaticClass.soundholder == false) {
            AudioListener.volume = MyStaticClass.soundholdervolume;
        }

        //PlayerPrefs.SetInt("Level3unlocked", 1);

        thescenename = "1";
        changelevelfade = false;
        GrabSceneName = SceneManager.GetActiveScene().name;
        startfade = true;
        //fadenumber = 0;
        fadenumber = 1;
        blackbackmainImage.GetComponent<Image>().enabled = true;
        titletext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);

        if (GrabSceneName == "0_Main Menu") {
            text2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
            text3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
            //text4.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
            //text5.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);


            //PokiUnitySDK.Instance.commercialBreakCallBack = commercialBreakComplete;
            //PokiUnitySDK.Instance.commercialBreak();
            
            

        }
        if (GrabSceneName == "1_Level Select") {

            //for (int i=2;i<30;i++) {
            //Level[i].GetComponent<Button>().interactable = false;
            //}

            Level2.GetComponent<Button>().interactable = false;
            Level3.GetComponent<Button>().interactable = false;
            Level4.GetComponent<Button>().interactable = false;
            Level5.GetComponent<Button>().interactable = false;
            Level6.GetComponent<Button>().interactable = false;
            Level7.GetComponent<Button>().interactable = false;
            Level8.GetComponent<Button>().interactable = false;
            Level9.GetComponent<Button>().interactable = false;
            Level10.GetComponent<Button>().interactable = false;
            Level11.GetComponent<Button>().interactable = false;
            Level12.GetComponent<Button>().interactable = false;
            Level13.GetComponent<Button>().interactable = false;
            Level14.GetComponent<Button>().interactable = false;
            Level15.GetComponent<Button>().interactable = false;
            Level16.GetComponent<Button>().interactable = false;
            Level17.GetComponent<Button>().interactable = false;
            Level18.GetComponent<Button>().interactable = false;
            Level19.GetComponent<Button>().interactable = false;
            Level20.GetComponent<Button>().interactable = false;
            Level21.GetComponent<Button>().interactable = false;
            Level22.GetComponent<Button>().interactable = false;
            Level23.GetComponent<Button>().interactable = false;
            Level24.GetComponent<Button>().interactable = false;
            Level25.GetComponent<Button>().interactable = false;
            Level26.GetComponent<Button>().interactable = false;
            Level27.GetComponent<Button>().interactable = false;
            Level28.GetComponent<Button>().interactable = false;
            Level29.GetComponent<Button>().interactable = false;
            Level30.GetComponent<Button>().interactable = false;

            ////
            Level1.text = "Level 1 - " + PlayerPrefs.GetInt("Level1CollectedEggs").ToString() + "/10";
            Level2.text = "Level 2 - " + PlayerPrefs.GetInt("Level2CollectedEggs").ToString() + "/10";
            Level3.text = "Level 3 - " + PlayerPrefs.GetInt("Level3CollectedEggs").ToString() + "/10";
            Level4.text = "Level 4 - " + PlayerPrefs.GetInt("Level4CollectedEggs").ToString() + "/10";
            Level5.text = "Level 5 - " + PlayerPrefs.GetInt("Level5CollectedEggs").ToString() + "/10";
            Level6.text = "Level 6 - " + PlayerPrefs.GetInt("Level6CollectedEggs").ToString() + "/10";
            Level7.text = "Level 7 - " + PlayerPrefs.GetInt("Level7CollectedEggs").ToString() + "/10";
            Level8.text = "Level 8 - " + PlayerPrefs.GetInt("Level8CollectedEggs").ToString() + "/10";
            Level9.text = "Level 9 - " + PlayerPrefs.GetInt("Level9CollectedEggs").ToString() + "/10";
            Level10.text = "Level 10 - " + PlayerPrefs.GetInt("Level10CollectedEggs").ToString() + "/10";
            Level11.text = "Level 11 - " + PlayerPrefs.GetInt("Level11CollectedEggs").ToString() + "/10";
            Level12.text = "Level 12 - " + PlayerPrefs.GetInt("Level12CollectedEggs").ToString() + "/10";
            Level13.text = "Level 13 - " + PlayerPrefs.GetInt("Level13CollectedEggs").ToString() + "/10";
            Level14.text = "Level 14 - " + PlayerPrefs.GetInt("Level14CollectedEggs").ToString() + "/10";
            Level15.text = "Level 15 - " + PlayerPrefs.GetInt("Level15CollectedEggs").ToString() + "/10";
            Level16.text = "Level 16 - " + PlayerPrefs.GetInt("Level16CollectedEggs").ToString() + "/10";
            Level17.text = "Level 17 - " + PlayerPrefs.GetInt("Level17CollectedEggs").ToString() + "/10";
            Level18.text = "Level 18 - " + PlayerPrefs.GetInt("Level18CollectedEggs").ToString() + "/10";
            Level19.text = "Level 19 - " + PlayerPrefs.GetInt("Level19CollectedEggs").ToString() + "/10";
            Level20.text = "Level 20 - " + PlayerPrefs.GetInt("Level20CollectedEggs").ToString() + "/10";
            Level21.text = "Level 21 - " + PlayerPrefs.GetInt("Level21CollectedEggs").ToString() + "/10";
            Level22.text = "Level 22 - " + PlayerPrefs.GetInt("Level22CollectedEggs").ToString() + "/10";
            Level23.text = "Level 23 - " + PlayerPrefs.GetInt("Level23CollectedEggs").ToString() + "/10";
            Level24.text = "Level 24 - " + PlayerPrefs.GetInt("Level24CollectedEggs").ToString() + "/10";
            Level25.text = "Level 25 - " + PlayerPrefs.GetInt("Level25CollectedEggs").ToString() + "/10";
            Level26.text = "Level 26 - " + PlayerPrefs.GetInt("Level26CollectedEggs").ToString() + "/10";
            Level27.text = "Level 27 - " + PlayerPrefs.GetInt("Level27CollectedEggs").ToString() + "/10";
            Level28.text = "Level 28 - " + PlayerPrefs.GetInt("Level28CollectedEggs").ToString() + "/10";
            Level29.text = "Level 29 - " + PlayerPrefs.GetInt("Level29CollectedEggs").ToString() + "/10";
            Level30.text = "Level 30 - " + PlayerPrefs.GetInt("Level30CollectedEggs").ToString() + "/10";
            ////
            if (PlayerPrefs.GetInt("Level2unlocked") == 1) {
                lock1.SetActive(false);
                Level2.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level3unlocked") == 1) {
                lock2.SetActive(false);
                Level3.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level4unlocked") == 1) {
                lock3.SetActive(false);
                Level4.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level5unlocked") == 1) {
                lock4.SetActive(false);
                Level5.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level6unlocked") == 1) {
                lock5.SetActive(false);
                Level6.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level7unlocked") == 1) {
                lock6.SetActive(false);
                Level7.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level8unlocked") == 1) {
                lock7.SetActive(false);
                Level8.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level9unlocked") == 1) {
                lock8.SetActive(false);
                Level9.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level10unlocked") == 1) {
                lock9.SetActive(false);
                Level10.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level11unlocked") == 1) {
                lock10.SetActive(false);
                Level11.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level12unlocked") == 1) {
                lock11.SetActive(false);
                Level12.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level13unlocked") == 1) {
                lock12.SetActive(false);
                Level13.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level14unlocked") == 1) {
                lock13.SetActive(false);
                Level14.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level15unlocked") == 1) {
                lock14.SetActive(false);
                Level15.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level16unlocked") == 1) {
                lock15.SetActive(false);
                Level16.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level17unlocked") == 1) {
                lock16.SetActive(false);
                Level17.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level18unlocked") == 1) {
                lock17.SetActive(false);
                Level18.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level19unlocked") == 1) {
                lock18.SetActive(false);
                Level19.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level20unlocked") == 1) {
                lock19.SetActive(false);
                Level20.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level21unlocked") == 1) {
                lock20.SetActive(false);
                Level21.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level22unlocked") == 1) {
                lock21.SetActive(false);
                Level22.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level23unlocked") == 1) {
                lock22.SetActive(false);
                Level23.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level24unlocked") == 1) {
                lock23.SetActive(false);
                Level24.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level25unlocked") == 1) {
                lock24.SetActive(false);
                Level25.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level26unlocked") == 1) {
                lock25.SetActive(false);
                Level26.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level27unlocked") == 1) {
                lock26.SetActive(false);
                Level27.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level28unlocked") == 1) {
                lock27.SetActive(false);
                Level28.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level29unlocked") == 1) {
                lock28.SetActive(false);
                Level29.GetComponent<Button>().interactable = true;
            }
            if (PlayerPrefs.GetInt("Level30unlocked") == 1) {
                lock29.SetActive(false);
                Level30.GetComponent<Button>().interactable = true;
            }
        }


    }

    private void FixedUpdate() {
        if (thecamera.transform.position.y > 6.5) {

            thecamera.transform.position = new Vector3(thecamera.transform.position.x, thecamera.transform.position.y - 3f * Time.deltaTime, thecamera.transform.position.z);

        }
    }

    void Update() {
      


        if (startfade == true) {
            fadenumber -= 1f * Time.deltaTime;
            fadenumber2 += 1f * Time.deltaTime;
            //Debug.Log(fadenumber);


            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);

            titletext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);

            if (GrabSceneName == "0_Main Menu") {
                text2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                text3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                //text4.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                //text5.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
            }

            if (fadenumber <= 0) {
                //text2.GetComponent<Button>().enabled = true;
                if (GrabSceneName == "0_Main Menu") {
                    text2.GetComponent<Button>().interactable = true;
                    text3.GetComponent<Button>().interactable = true;
                    //text4.GetComponent<Button>().interactable = true;
                    //text5.GetComponent<Button>().interactable = true;
                }
                startfade = false;
                fadenumber = 0;
                blackback.SetActive(false);
            }
        }

        if (startfade == false && changelevelfade == true) {
            fadenumber += 1f * Time.deltaTime;
            //Debug.Log(fadenumber);
            blackback.SetActive(true);
            blackbackmainImage.GetComponent<Image>().canvasRenderer.SetAlpha(fadenumber);

            fadenumber2 -= 1f * Time.deltaTime;
            if (GrabSceneName == "0_Main Menu") {
                titletext.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                text2.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                text3.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                //text4.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
                //text5.GetComponent<Text>().canvasRenderer.SetAlpha(fadenumber2);
            }

            if (fadenumber >= 1) {
                changelevelfade = false;
                SceneManager.LoadSceneAsync(thescenename);
            }
        }
    }



    public void PlayGameButton() {
        changelevelfade = true;
        thescenename = "Level 1";
    }

    public void PlayLevel2() {
        changelevelfade = true;
        thescenename = "Level 2";
    }
    public void PlayLevel3() {
        changelevelfade = true;
        thescenename = "Level 3";
    }
    public void PlayLevel4() {
        changelevelfade = true;
        thescenename = "Level 4";
    }
    public void PlayLevel5() {
        changelevelfade = true;
        thescenename = "Level 5";
    }
    public void PlayLevel6() {
        changelevelfade = true;
        thescenename = "Level 6";
    }
    public void PlayLevel7() {
        changelevelfade = true;
        thescenename = "Level 7";
    }
    public void PlayLevel8() {
        changelevelfade = true;
        thescenename = "Level 8";
    }
    public void PlayLevel9() {
        changelevelfade = true;
        thescenename = "Level 9";
    }
    public void PlayLevel10() {
        changelevelfade = true;
        thescenename = "Level 10";
    }
    public void PlayLevel11() {
        changelevelfade = true;
        thescenename = "Level 11";
    }
    public void PlayLevel12() {
        changelevelfade = true;
        thescenename = "Level 12";
    }
    public void PlayLevel13() {
        changelevelfade = true;
        thescenename = "Level 13";
    }
    public void PlayLevel14() {
        changelevelfade = true;
        thescenename = "Level 14";
    }
    public void PlayLevel15() {
        changelevelfade = true;
        thescenename = "Level 15";
    }
    public void PlayLevel16() {
        changelevelfade = true;
        thescenename = "Level 16";
    }
    public void PlayLevel17() {
        changelevelfade = true;
        thescenename = "Level 17";
    }
    public void PlayLevel18() {
        changelevelfade = true;
        thescenename = "Level 18";
    }
    public void PlayLevel19() {
        changelevelfade = true;
        thescenename = "Level 19";
    }
    public void PlayLevel20() {
        changelevelfade = true;
        thescenename = "Level 20";
    }
    public void PlayLevel21() {
        changelevelfade = true;
        thescenename = "Level 21";
    }
    public void PlayLevel22() {
        changelevelfade = true;
        thescenename = "Level 22";
    }
    public void PlayLevel23() {
        changelevelfade = true;
        thescenename = "Level 23";
    }
    public void PlayLevel24() {
        changelevelfade = true;
        thescenename = "Level 24";
    }
    public void PlayLevel25() {
        changelevelfade = true;
        thescenename = "Level 25";
    }
    public void PlayLevel26() {
        changelevelfade = true;
        thescenename = "Level 26";
    }
    public void PlayLevel27() {
        changelevelfade = true;
        thescenename = "Level 27";
    }
    public void PlayLevel28() {
        changelevelfade = true;
        thescenename = "Level 28";
    }
    public void PlayLevel29() {
        changelevelfade = true;
        thescenename = "Level 29";
    }
    public void PlayLevel30() {
        changelevelfade = true;
        thescenename = "Level 30";
    }


    public void LevelSelectButton() {
        //PokiUnitySDK.Instance.gameplayStop();
        ////////
        changelevelfade = true;
        thescenename = "1_Level Select";
    }



    //////
    public void Button3() {
        Debug.Log("Button3");
    }

    public void Button4() {
        Debug.Log("Button4");
    }

    public void SoundSelect() {
        if (GrabSceneName == "0_Main Menu") {
            if (text2.GetComponent<Button>().interactable == true) {
                AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
            }
        }
        if (GrabSceneName == "1_Level Select") {
             AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }

    public void SoundSelect2() {
        if (Level2.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect3() {
        if (Level3.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect4() {
        if (Level4.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect5() {
        if (Level5.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }

    public void SoundSelect6() {
        if (Level6.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect7() {
        if (Level7.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect8() {
        if (Level8.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect9() {
        if (Level9.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect10() {
        if (Level10.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect11() {
        if (Level11.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect12() {
        if (Level12.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect13() {
        if (Level13.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect14() {
        if (Level14.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect15() {
        if (Level15.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect16() {
        if (Level16.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect17() {
        if (Level17.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect18() {
        if (Level18.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect19() {
        if (Level19.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect20() {
        if (Level20.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect21() {
        if (Level21.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect22() {
        if (Level22.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect23() {
        if (Level23.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect24() {
        if (Level24.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect25() {
        if (Level25.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect26() {
        if (Level26.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect27() {
        if (Level27.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect28() {
        if (Level28.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect29() {
        if (Level29.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }
    public void SoundSelect30() {
        if (Level30.GetComponent<Button>().interactable == true) {
            AudioSource.PlayClipAtPoint(cursorsound, Camera.main.transform.position, 0.15f);
        }
    }



  


}
