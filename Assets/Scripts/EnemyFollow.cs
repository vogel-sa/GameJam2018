using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

	[SerializeField]
	private float speed = 1f;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D rc;
		if (rc = Physics2D.Raycast (transform.position,
			MovePlayer.Instance.currPlayer.transform.position - transform.position,
			Mathf.Infinity,
				LayerMask.GetMask("Wall", "Character"))) {
			if (rc.collider.gameObject == MovePlayer.Instance.currPlayer.gameObject)
				rb.velocity = (MovePlayer.Instance.currPlayer.transform.position - transform.position).normalized * speed;
			else
				rb.velocity = Vector2.zero;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(new Ray(transform.position,
			MovePlayer.Instance.currPlayer.transform.position - transform.position));
	}
}
