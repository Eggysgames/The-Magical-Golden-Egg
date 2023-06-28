using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcodedThings : MonoBehaviour {

    public GameObject whitechicken;
    public Sprite mythis;

    private Color mycolour;
    public float colourfade = 1;
    public bool switcher;

    public float pos1;
    public float pos2;

    void Start() {

        switcher = true;
        GetComponent<SpriteRenderer>().enabled = false;
        mycolour = GetComponent<SpriteRenderer>().color;
        mycolour.a = 1f;

    }


    void Update() {

        if (whitechicken != null) {

            if (colourfade <= 0.1) {
                switcher = true;
            }
            if (colourfade >= 0.9) {
                switcher = false;
            }
            if (switcher == true) {
                colourfade += 0.005f;
                mycolour.a = colourfade;
                GetComponent<SpriteRenderer>().color = mycolour;
            }
            if (switcher == false) {
                colourfade -= 0.005f;
                mycolour.a = colourfade;
                GetComponent<SpriteRenderer>().color = mycolour;
            }

            if (whitechicken.transform.position.x > pos1) {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (whitechicken.transform.position.x > pos2) {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
