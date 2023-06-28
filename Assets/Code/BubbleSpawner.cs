using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

    private Bubble bubblecode;

    public GameObject Bubble;
    private bool release;
    private float timer;
    private GameObject holder;

    
    void Start() {

        timer = 0;
        release = false;

        
    }

    
    void Update() {

        timer += 1 * Time.deltaTime;

        if (release == false && timer > 6) {
            holder = Instantiate(Bubble, new Vector2(this.transform.position.x, this.transform.position.y + 0.3f), this.transform.rotation);
            bubblecode = holder.GetComponent<Bubble>();
            bubblecode.pausebubble = true;
            timer = 0;

            Vector3 theScale = holder.transform.localScale;
            theScale.x = 0.4f;
            theScale.y = 0.4f;
            holder.transform.localScale = theScale;

            //holder.transform.Vector3 theScale = transform.localScale;
        }



        
    }
}
