using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoint : MonoBehaviour {

    private Skeleton skeletoncode;
    private Chicken chickencode;
    private WhiteChicken whitechickencode;
    private Main maincode;

    public bool ready;
    public bool ready2;
    public GameObject sparks;

    void Start() {
        //ready = false;
        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Chicken") {
            if (ready) {
                chickencode = col.transform.gameObject.GetComponent<Chicken>();
                chickencode.Chickendeath();
            }
        }
        if (col.gameObject.tag == "WhiteChicken") {
            if (ready2 && maincode.countdown >= 0.5) {
                maincode.ShieldEffectDisplay();
            }
            if (ready && maincode.countdown <0.5) {
                whitechickencode = col.transform.gameObject.GetComponent<WhiteChicken>();
                whitechickencode.Chickendeath();
            }
        }
    }




    void Update() { 
    
        
    }
}
