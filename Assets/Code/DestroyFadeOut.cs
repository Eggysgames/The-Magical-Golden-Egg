using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFadeOut : MonoBehaviour { 

public float deathremovetimer;

private Color mycolour;
private float colourfade = 1;



void Start() {
	mycolour = GetComponent<SpriteRenderer>().color;
	mycolour.a = 1f;
}


	void Update() {

		deathremovetimer -= Time.deltaTime;

		if (deathremovetimer <= 0) {
			colourfade -= 0.1f;
			mycolour.a = colourfade;
			GetComponent<SpriteRenderer>().color = mycolour;
			if (colourfade <= 0) {
				Destroy(gameObject);
			}
		}


	}

}
