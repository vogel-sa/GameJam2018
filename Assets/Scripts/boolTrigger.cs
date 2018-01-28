using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolTrigger : MonoBehaviour {

	public bool cond = false;
	public GameObject activator;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject == activator) {
			cond = true;
		}
	}
}
