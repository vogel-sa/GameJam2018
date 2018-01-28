using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayTrigger : MonoBehaviour {
	[SerializeField]
	GameObject char1, char2;
	private bool t1, t2;
	[SerializeField]
	Collider2D b1, b2;
	[SerializeField]
	Toggleable[] effects;
	
	// Update is called once per frame
	void Update () {
		if (t1 && t2) {
			foreach (var t in effects)
				t.Toggle ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == char1){
			t1 = true;
		}
		if (other.gameObject == char2){
			t2 = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject == char1){
			t1 = false;
		}
		if (other.gameObject == char2){
			t2 = false;
		}
	}
}
