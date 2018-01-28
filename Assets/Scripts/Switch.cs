using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	[SerializeField]
	private Toggleable[] effects;
	public bool activate = false;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == MovePlayer.Instance.currPlayer.gameObject)
			activate = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject == MovePlayer.Instance.currPlayer.gameObject)
			activate = false;
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E) && activate) {
			foreach (var t in effects) {
				t.Toggle ();
			}
		}

	}
}
