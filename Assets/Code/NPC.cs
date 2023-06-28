using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NPC : MonoBehaviour {

    public GameObject whitechicken;
    public GameObject speechbubble;
    public string npcname;
    public string inputspeech;
    public string inputspeech2; 
    public Text speechtext;
    public GameObject textobject;
    public GameObject brokenheart;
    public GameObject heartposition;
    public bool DisplayAnInstance;

    private float distancecheck;
    private bool speech1check;
    private bool speech2check;

    public AudioClip soundeffect;
    public AudioClip soundeffect2;

    void Start() {
        speech1check = false;
        speech2check = false;
    }


    void Update() {

        //Debug.Log(this.transform.position.x - whitechicken.transform.position.x);

        if (whitechicken != null) {
            distancecheck = this.transform.position.x - whitechicken.transform.position.x;

            if (distancecheck < 5 && speech1check == false && whitechicken.transform.position.x < this.transform.position.x) {
                speech1();
                if (soundeffect != null) {
                    AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.7f);
                }
                    speech1check = true;
            }

            if (distancecheck < -1 && speech2check == false && whitechicken.transform.position.x > this.transform.position.x) {
                speech2();
                if (soundeffect != null) {
                    AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.7f);
                }
                speech2check = true;
                if (DisplayAnInstance == true) {
                    Instantiate(brokenheart, heartposition.transform.position, heartposition.transform.rotation);
                }
            }
            if (distancecheck < -3 && speech2check == true && whitechicken.transform.position.x > this.transform.position.x) {
                speechbubble.SetActive(false);
                inputspeech = "";
                speechtext.text = inputspeech.ToString();
            }
            //Debug.Log(distancecheck);
        }
    }

    void speech1() {
        speechtext.GetComponent<Text>().enabled = true;

        speechbubble.SetActive(true);
        inputspeech = "<color=red>" + npcname + "</color>" + ": " + inputspeech;
        speechtext.text = inputspeech.ToString();
    }
    void speech2() {
        speechtext.GetComponent<Text>().enabled = true;

        speechbubble.SetActive(true);
        inputspeech = "<color=red>" + npcname + "</color>" + ": " + inputspeech2;
        speechtext.text = inputspeech.ToString();
    }
}
