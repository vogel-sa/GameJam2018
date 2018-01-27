using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTransfer : MonoBehaviour {
	[SerializeField]
	private GameObject[] chars;
	[SerializeField]
	private GameObject[] interactUI;
	[SerializeField]
	private string[] interactButtons;

	void Start()
	{
		foreach (var ui in interactUI) ui.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (MovePlayer.Instance.currPlayer.gameObject == col.gameObject)
			for (int i = 0; i < interactUI.Length; i++) {
				if (MovePlayer.Instance.currPlayer.gameObject != chars[i])
					interactUI[i].SetActive (true);
			}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (MovePlayer.Instance.currPlayer.gameObject == col.gameObject)
			for (int i = 0; i < interactUI.Length; i++) {
				//if (MovePlayer.Instance.currPlayer.gameObject != chars[i])
					interactUI[i].SetActive (false);
			}
	}

	void Update()
	{
		for (int i = 0; i < interactButtons.Length; i++) {
			
			if (Input.GetKeyDown (interactButtons[i])) {
				MovePlayer.Instance.currPlayer.velocity = Vector3.zero;
				MovePlayer.Instance.currPlayer = chars [i].GetComponent<Rigidbody2D>();
				RefreshUI ();
			}
		}
	}

	void RefreshUI()
	{
		for (int i = 0; i < interactUI.Length; i++) {
			if (MovePlayer.Instance.currPlayer.gameObject != chars [i])
				interactUI [i].SetActive (true);
			else
				interactUI [i].SetActive (false);
		}
	}
}