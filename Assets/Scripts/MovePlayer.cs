using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private Rigidbody2D _currPlayer;
	public Rigidbody2D currPlayer {
		get
		{
			return _currPlayer;
		}
		set
		{
			_currPlayer = value;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float vertical = Input.GetAxisRaw ("Vertical");
		float horizontal = Input.GetAxisRaw ("Horizontal");
		Vector3 vec = new Vector3 (horizontal, vertical, 0f);
		vec *= speed;
		currPlayer.velocity = vec;
	}
}
