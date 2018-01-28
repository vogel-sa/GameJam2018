using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	private bool closeEnough = false;
	[SerializeField]
	private Sprite openSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && closeEnough) {
			GetComponent<SpriteRenderer> ().sprite = openSprite;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == MovePlayer.Instance.currPlayer.gameObject){
			closeEnough = true;

		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject == MovePlayer.Instance.currPlayer.gameObject){            
			closeEnough = false;

		}

	}
}
