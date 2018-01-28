using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour {

	[SerializeField]
	float cameraZ = 0;
	[SerializeField]
	Vector2 side1, side2;
	[SerializeField]
	Transform cam1, cam2;
	private bool closeEnough = false;
	[SerializeField]
	private bool isSceneTransition = false;
	[SerializeField]
	private string nextScene = "";

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && closeEnough) {
			if (isSceneTransition) {
				SceneManager.LoadScene (nextScene);
			} else {
                // PLaY OPEN DOOR SOUND
                this.transform.parent.GetComponent<AudioSource>().Play();
				Vector2 charpos = MovePlayer.Instance.currPlayer.transform.position;
				Vector2 closer;
				Vector3 campos;
				if (Vector2.Distance (charpos, side1) < Vector2.Distance (charpos, side2)) {
					closer = side2;
					campos = cam2.position;
				} else {
					closer = side1;
					campos = cam1.position;
				}
				MovePlayer.Instance.currPlayer.transform.position = closer;
				Camera.main.transform.position = campos;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == MovePlayer.Instance.currPlayer.gameObject){
			closeEnough = true;

		}

	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject == MovePlayer.Instance.currPlayer.gameObject){            
			closeEnough = false;

		}

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere (side1, .1f);
		Gizmos.DrawSphere (side2, .1f);
	}
}
