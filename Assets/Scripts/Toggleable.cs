using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour {
	public void Toggle () {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.SetActive (!transform.GetChild (i).gameObject.activeSelf);
		}
	}
}
