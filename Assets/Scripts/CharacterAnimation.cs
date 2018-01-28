using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D body;
	private bool isPlaying = false;
	[SerializeField]
	private float rotationSpeed = 5f;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		body = GetComponentInParent<Rigidbody2D> ();
		animator.StopPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("v", body.velocity.magnitude);
		if (body.velocity != Vector2.zero) {
			Vector3 moveDirection = -body.velocity.normalized; 
			if (moveDirection != Vector3.zero) 
			{
				float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		}


	}
}
