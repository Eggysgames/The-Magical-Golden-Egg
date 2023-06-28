using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    private Main maincode;

    private Animator myAnimator;
    public GameObject spirit;
    public GameObject holder;
    public int timer;
    public bool switcher;
    public GameObject smokepuff;

    public AudioClip returnsound;

    void Start() {

        maincode = GameObject.Find("MyCamera").GetComponent<Main>();
        switcher = false;
        myAnimator = GetComponent<Animator>();

    }

    void Update() {
        ReturnSpell();
        ////////////

        timer++;

        if (timer > 200) {
            switcher = !switcher;
            timer = 0;
        }
        if (switcher == true) {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.0003f);
        }
        if (switcher == false) {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.0003f);
        }

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x <0) {
            holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
            holder.GetComponent<Spirit>().backtoegg = true;
            Destroy(gameObject);
        }
        
    }

    void ReturnSpell() {
        if (maincode.unlocktheui >= 3) {
            if (Input.GetButtonDown("RSpell")) {
                AudioSource.PlayClipAtPoint(returnsound, Camera.main.transform.position, 0.08f);
                Instantiate(smokepuff, this.gameObject.transform.position, this.gameObject.transform.rotation);
                holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
                holder.GetComponent<Spirit>().backtoegg = true;
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Chicken") {
            //AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.05f);
            myAnimator.SetTrigger("press");
        }
        if (col.gameObject.tag == "WhiteChicken") {
            //AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.05f);
            myAnimator.SetTrigger("press");
        }
    }
}