using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticChicken : MonoBehaviour {

    public int speed;
    public bool mydirection;
    public GameObject holder;
    public GameObject spirit;
    public GameObject purplepuff;
    public Rigidbody2D ChickenRB;

    void Start() {
        speed = 1;
        //mydirection = false;
    }


    void Update() {

        if (mydirection) {
            ChickenRB.velocity = new Vector2(1 * speed, ChickenRB.velocity.y);
        }
        if (!mydirection) {
            ChickenRB.velocity = new Vector2(-1 * speed, ChickenRB.velocity.y);
        }

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);


        if (RelativeCameraPosition.x < 0) {
            Chickendeath2();
        }

        if (this.gameObject.transform.position.x < -31.68 && mydirection == false) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            mydirection = !mydirection;
        }
        if (this.gameObject.transform.position.x > -26.7 && mydirection == true) {
            
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            mydirection = !mydirection;
        }

    }

    public void Chickendeath2() {

        //PiecesXY = this.gameObject.transform.position;

        Instantiate(purplepuff, gameObject.transform.position, this.gameObject.transform.rotation);

        holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
        holder.GetComponent<Spirit>().backtoegg = true;

        Destroy(gameObject);

    }
}
