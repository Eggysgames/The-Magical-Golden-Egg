using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spirit : MonoBehaviour {

    public Main maincode;

    public GameObject goldenegg;
    public GameObject chicken;
    public GameObject spring;
    public GameObject smokepuff;
    public GameObject yellowreturnspark;
    public float speed;
    public float mydistance;
    public bool backtoegg;
    public int getreadytodie;
    public bool runonce;
    public bool whichside; 

    public Vector3 mouseXY;

    public int whattospawn;

    void Start() {
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        goldenegg = GameObject.Find("GoldenEgg");
        /////
        whattospawn = maincode.whattospawn;
        runonce = false;
        getreadytodie = 0;
    }


    void Update() {

        if (goldenegg != null) {

            if (speed > 35) {
                speed = 35;
            }

            if (backtoegg == true) {

                this.transform.position = Vector2.MoveTowards(gameObject.transform.position, goldenegg.transform.position, speed * Time.deltaTime);
                mydistance = Vector2.Distance(gameObject.transform.position, goldenegg.transform.position);
                speed += 0.5f;


                if (mydistance < 0.1) {
                    if (runonce == false) {
                        Instantiate(yellowreturnspark, gameObject.transform.position, this.gameObject.transform.rotation);


                        if (this.transform.position.x < goldenegg.transform.position.x) {
                            whichside = true;
                        }
                        if (this.transform.position.x > goldenegg.transform.position.x) {
                            whichside = false;
                        }
                        maincode.whichside = whichside;
                        maincode.Adder();
                        runonce = true;
                    }
                    getreadytodie++;
                }
            }

            if (backtoegg == false) {

                this.transform.position = Vector2.MoveTowards(gameObject.transform.position, mouseXY, Time.deltaTime * speed);
                mydistance = Vector2.Distance(gameObject.transform.position, mouseXY);
                speed += 0.3f;

                if (mydistance < 0.1) {

                    if (whattospawn == 1) {
                        Instantiate(smokepuff, mouseXY, this.gameObject.transform.rotation);
                        Instantiate(chicken, mouseXY, this.gameObject.transform.rotation);
                    }
                    if (whattospawn == 2) {
                        mouseXY.z = 0.01f;
                        Instantiate(smokepuff, mouseXY, this.gameObject.transform.rotation);
                        Instantiate(spring, mouseXY, this.gameObject.transform.rotation);
                    }

                    Destroy(gameObject);
                }
            }

            if (getreadytodie > 50) {
                Destroy(gameObject);
            }

        }

    }
}
