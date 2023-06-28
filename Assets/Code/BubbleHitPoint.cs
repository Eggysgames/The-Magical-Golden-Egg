using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHitPoint : MonoBehaviour {

    private Bubble bubblecode;

    public GameObject Brownchickenpicture;

    void Start() {


    }



    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Chicken") {
            if (Brownchickenpicture.activeSelf == false) {

                bubblecode = transform.parent.gameObject.GetComponent<Bubble>();

                bubblecode.occupied = 1;
                Brownchickenpicture.SetActive(true);
                Destroy(col.gameObject);

            }


        }
    }
}




