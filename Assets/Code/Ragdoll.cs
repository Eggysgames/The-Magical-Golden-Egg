using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {

	public Rigidbody2D headR;
	public Rigidbody2D bodyR;
	public Rigidbody2D legL;
	public Rigidbody2D legR;

    public SpriteRenderer head;
    public SpriteRenderer frontarm;
    public SpriteRenderer behindarm;
    public SpriteRenderer behindleg;

    void Start() {
		headR = this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();
		bodyR = this.gameObject.transform.GetChild(1).GetComponent<Rigidbody2D>();
		legL = this.gameObject.transform.GetChild(2).GetComponent<Rigidbody2D>();
		legR = this.gameObject.transform.GetChild(3).GetComponent<Rigidbody2D>();
		///
		head = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
		frontarm = this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
		behindarm = this.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
		behindleg = this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();
		//
		//behindleg.sortingOrder = maincode.ragdollorder;
		//behindarm.sortingOrder = maincode.ragdollorder + 1;
		//mytorso.sortingOrder = maincode.ragdollorder + 2;
		//frontarm.sortingOrder = maincode.ragdollorder + 3;
		//frontleg.sortingOrder = maincode.ragdollorder + 4;
		//head.sortingOrder = maincode.ragdollorder + 5;
		//maincode.ragdollorder += 6;
		//Debug.Log (maincode.increaseorder);
		//
	}


	
	}
	