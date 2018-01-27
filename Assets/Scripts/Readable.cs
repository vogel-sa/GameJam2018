using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Readable : MonoBehaviour {

	bool readable = false;
	CircleCollider2D col;
	private CircleCollider2D trigger;
	[SerializeField]
	Text text;
	[SerializeField]
	string message = "";

	// Use this for initialization
	void Start () {
		col = (from x in GetComponents<CircleCollider2D> ()
			where x.isTrigger
			select x).First ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && Vector2.Distance(MovePlayer.Instance.currPlayer.transform.position,
			transform.position) <= col.radius * transform.localScale.x + MovePlayer.Instance.radius)
		{
			text.text = message;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == MovePlayer.Instance.currPlayer.gameObject){
			readable = true;

		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject == MovePlayer.Instance.currPlayer.gameObject){            
			readable = false;
			text.text = "";
		}

	}
}
