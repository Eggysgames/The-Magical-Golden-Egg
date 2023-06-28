using UnityEngine;
using System.Collections;

public class Motorbike : MonoBehaviour {



    public Rigidbody2D player;
    private Animator myAnimator;




    public bool grounded;

    public Transform wheel1;
    public Transform wheel2;


    

    void Start() {
        //Debug.Log("What the fuck");
        //speed = 8;
        //jumpheight = 1500;


    }


    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);
        inputkeys();
        ////

        



    grounded = Physics2D.Linecast(wheel1.position, wheel2.position, 1 << LayerMask.NameToLayer("Ground"));


        //Allows us to see it
        Debug.DrawLine(wheel1.position, wheel2.position);

        ///Say if it Collided
        //Debug.Log(grounded);




    }



    void Movement(float horizontal) {

        //if (grounded) {

            player.AddForce (new Vector2 (horizontal*6, 0));
            //player.velocity = new Vector2(horizontal * speed, player.velocity.y);
            //myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        //}
    }


    void inputkeys() {
        //if (Input.GetButtonDown("Gas") && grounded) {

            //player.AddForce(new Vector2(player.velocityf, 0));

            //player.AddForce(transform.right * 33);

            //Debug.Log("Vroom");
            //player.velocity = Vector3.zero;
            //player.AddForce(new Vector2(0, jumpheight));
            //myAnimator.SetTrigger("press");

            ////
        //}
    }

}