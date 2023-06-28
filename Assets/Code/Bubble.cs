using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    private Rigidbody2D BubbleRB;
    public float speed;
    private GameObject holder;

    public GameObject spirit;
    public GameObject chicken;
    public GameObject bubblesmokepuff;

    public int occupied;
    public bool pausebubble;

    public AudioClip popsound;

    void Start() {

        occupied = 0;
        speed = Random.Range(0.1f, 0.3f);
        BubbleRB = GetComponent<Rigidbody2D>();

    }

    void Update() {


        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x >= 1) {
            Pop3();
        }
        if (RelativeCameraPosition.x < 0) {
            Pop3();
        }
        if (RelativeCameraPosition.y < 0) {
            Pop3();
        }
        if (RelativeCameraPosition.y > 1) {
            Pop3();
        }

        BubbleRB.velocity = new Vector2(BubbleRB.velocity.x, speed);

        if (pausebubble == true) {
            speed = 1f;
            Vector3 theScale = transform.localScale;
            theScale.x += 0.002f;
            theScale.y += 0.002f;
            transform.localScale = theScale;

            if (theScale.x > 1) {
                pausebubble = false;
                speed = 0.1f;
            }
        } 

    }



    public void Pop() {

        if (occupied == 0) {
            Instantiate(bubblesmokepuff, gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if (occupied == 1) {
            holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
            holder.GetComponent<Spirit>().backtoegg = true;
        }
        AudioSource.PlayClipAtPoint(popsound, Camera.main.transform.position, 0.4f);

        Destroy(gameObject);
    }

    public void Pop2() {
        if (occupied == 0) {
            Instantiate(bubblesmokepuff, gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if (occupied == 1) {
            Instantiate(chicken, gameObject.transform.position, Quaternion.Euler(0,0,0));
            
        }
        AudioSource.PlayClipAtPoint(popsound, Camera.main.transform.position, 0.4f);

        Destroy(gameObject);
    }
    public void Pop3() {
        if (occupied == 0) {
            Instantiate(bubblesmokepuff, gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if (occupied == 1) {
            Instantiate(chicken, gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        }
        

        Destroy(gameObject);
    }

}
