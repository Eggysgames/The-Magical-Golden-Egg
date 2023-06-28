using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Rigidbody2D ArrowRB;
    public GameObject richochet;
    private Vector3 PiecesXY;
    public AudioClip soundeffect;
    public AudioClip soundeffect2;

    void Start() {

        ArrowRB = this.gameObject.GetComponent<Rigidbody2D>();
        
    }


    void Update() {

        transform.position += -transform.right * 6 * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, 0, 30f * Time.deltaTime);


        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x >= 1) {
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.x < -0.5) {
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.y < 0) {
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.y > 1) {
            Destroy(gameObject);
        }

    }

  

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Chicken") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.2f);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "WhiteChicken") {
            AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.2f);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ground") {
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.2f);
            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y - 0.4f), this.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Shield") {
            AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.2f);
            PiecesXY = this.gameObject.transform.position;
            Instantiate(richochet, new Vector2(PiecesXY.x - 0.3f, PiecesXY.y), this.transform.rotation);
            Destroy(gameObject);
        }
        
    }


}
