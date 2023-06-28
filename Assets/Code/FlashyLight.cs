using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashyLight : MonoBehaviour {

    public GameObject mylight;
    public float timer;

    void Start() {
        timer = 0;

    }


    void Update() {
        timer += 1 * Time.timeScale;

        if (timer > 300) {
            mylight.SetActive(false);
        }
        if (timer > 320) {
            mylight.SetActive(true);
        }
        if (timer > 340) {
            mylight.SetActive(false);
        }
        if (timer > 400) {
            mylight.SetActive(true);
            timer = 0;
        }
    }
}
