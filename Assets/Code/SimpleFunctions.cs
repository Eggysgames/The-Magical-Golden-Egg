using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFunctions : MonoBehaviour {

    public AudioClip cursorsound;
    public AudioSource soundplayer;

    public void Start() {
        soundplayer = GameObject.Find("MyCamera").GetComponent<AudioSource>();
    }

    public void SoundSelect() {

        soundplayer.clip = cursorsound;
        soundplayer.Play();


    }


}
