using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalEffect : MonoBehaviour {

	public boolTrigger[] conditions;
	public Toggleable[] effects;
	// Update is called once per frame
	void Update () {
		foreach (var c in conditions) {
			if (!c.cond) {
				break;
			} else {
				foreach (var t in effects)
					t.Toggle ();
			}
		}
	}
}
