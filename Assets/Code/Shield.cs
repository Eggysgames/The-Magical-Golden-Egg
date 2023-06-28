using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject whitechicken;
    private Main maincode;

    public AudioClip shieldsound;

    void Start() {

        AudioSource.PlayClipAtPoint(shieldsound, Camera.main.transform.position, 0.5f);
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        whitechicken = GameObject.Find("WhiteChicken");

    }


    void Update() {

        if (whitechicken != null) {
            this.transform.position = whitechicken.transform.position;
        }

        if (maincode.reloading == false || maincode.countdown <= 0.5) {
            Destroy(gameObject);
        }

    }
}
