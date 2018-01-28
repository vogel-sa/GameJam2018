using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MirrorTransfer : MonoBehaviour {
	[SerializeField]
	private GameObject[] chars;
	[SerializeField]
	private Transform camPosParent;
	private Transform[] camPosns;

	public bool canSwap = false;

	void Start()
	{
		camPosns = camPosParent.GetComponentsInChildren<Transform> ();
		canSwap = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == MovePlayer.Instance.currPlayer.gameObject)
			canSwap = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject == MovePlayer.Instance.currPlayer.gameObject)
			canSwap = false;
	}



	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E) && canSwap) {
			var closest = camPosns.OrderBy (x => Vector2.Distance (x.position, MovePlayer.Instance.currPlayer.transform.position))
				.First ();
				
			Camera.main.transform.position = closest.position;
			MovePlayer.Instance.currPlayer.velocity = Vector3.zero;
			MovePlayer.Instance.currPlayer = chars.Where (x => x.GetComponent<Rigidbody2D> () != MovePlayer.Instance.currPlayer)
				.First ().GetComponent<Rigidbody2D>();
		}

	}
	/*
	void RefreshUI()
	{
		for (int i = 0; i < interactUI.Length; i++) {
			if (MovePlayer.Instance.currPlayer.gameObject != chars [i])
				interactUI [i].SetActive (true);
			else
				interactUI [i].SetActive (false);
		}
	}
	*/
}