using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPrefab : MonoBehaviour {
	private static ReloadPrefab _instance;
	public static ReloadPrefab Instance
	{
		get
		{
			if (!_instance && !(_instance = FindObjectOfType<ReloadPrefab>()))
			{
				_instance = new GameObject().AddComponent<ReloadPrefab>();
			}
			return _instance;
		}
	}

	private GameObject goRef = null;

	[SerializeField]
	string path;

	public void CreatePrefab()
	{
		goRef = GameObject.Instantiate (Resources.Load<GameObject> (path));
	}

	public void Reload()
	{
		GameObject.Destroy(goRef);
		CreatePrefab();
	}

	void Awake()
	{
		CreatePrefab ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Reload ();
		}
	}
}
