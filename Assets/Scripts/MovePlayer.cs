using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private Transform _currPlayer;
	public Transform currPlayer {
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
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		currPlayer.Translate(new Vector3(horizontal, vertical, 0f));
	}
}
