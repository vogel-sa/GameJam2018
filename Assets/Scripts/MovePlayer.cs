using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{
	private static MovePlayer _instance;
	public static MovePlayer Instance
	{
		get
		{
			if (!_instance && !(_instance = FindObjectOfType<MovePlayer>()))
			{
				_instance = new GameObject ().AddComponent<MovePlayer> ();
			}
			return _instance;
		}
	}
	[SerializeField]
	private float speed = 5f;
	public float radius = 0f;
	[SerializeField]
	public Rigidbody2D _currPlayer;
	public Rigidbody2D currPlayer
	{
		get
		{
			return _currPlayer;
		}
		set
		{
			_currPlayer = value;
		}
	}

	void Start()
	{
		radius = currPlayer.GetComponent<CircleCollider2D> ().radius * currPlayer.transform.localScale.x;
	}

	void Update ()
	{
		float vertical = Input.GetAxisRaw ("Vertical");
		float horizontal = Input.GetAxisRaw ("Horizontal");
		Vector3 vec = new Vector3 (horizontal, vertical, 0f);
		vec *= speed;
		currPlayer.velocity = vec;
	}
}