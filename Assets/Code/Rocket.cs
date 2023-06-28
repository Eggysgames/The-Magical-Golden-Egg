using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody2D RocketRB;
    public GameObject richochet;
    private Vector3 PiecesXY;
    public GameObject spirit;
    private GameObject holder;
    private float speed;

    public AudioClip soundeffect;
    public AudioClip soundeffect2;

    void Start() {

        speed = 6;
        AudioSource.PlayClipAtPoint(soundeffect, Camera.main.transform.position, 0.25f);

        RocketRB = this.gameObject.GetComponent<Rigidbody2D>();

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }


    void Update() {

        transform.position += -transform.right * speed * Time.deltaTime;

        speed += 6 * Time.deltaTime;

        //Debug.Log(speed);
        

        Vector3 RelativeCameraPosition = Camera.main.WorldToViewportPoint(this.transform.position);

        if (RelativeCameraPosition.x >= 1) {
            Death();
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.x < 0) {
            Death();
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.y < 0) {
            Death();
            Destroy(gameObject);
        }
        if (RelativeCameraPosition.y > 1) {
            Death();
            Destroy(gameObject);
        }


    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D col) {
        

        if (col.gameObject.tag == "Ground") {
            Death();
        }

        if (col.gameObject.tag == "Metalbox") {
            Death();
        }

    }


    void Death() {

        AudioSource.PlayClipAtPoint(soundeffect2, Camera.main.transform.position, 0.25f);

        holder = Instantiate(spirit, gameObject.transform.position, this.gameObject.transform.rotation);
        holder.GetComponent<Spirit>().backtoegg = true;
        //
        PiecesXY = this.gameObject.transform.position;
        Instantiate(richochet, new Vector2(PiecesXY.x, PiecesXY.y), this.transform.rotation);
        Destroy(gameObject);
    }


}
