﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSwitch : MonoBehaviour {

	[SerializeField]
	private Toggleable[] effects;
	[SerializeField]
	GameObject key;

	private bool activated = false;

	void OnTriggerEnter2D(Collider2D other){
		if (!activated && (!key || other.gameObject == key)) {
			foreach (var t in effects) {
				t.Toggle ();
			}
			activated = true;
		}
	}
}