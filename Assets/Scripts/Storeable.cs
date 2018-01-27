using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CircleCollider2D))]
public class Storeable : MonoBehaviour
{
    bool storable = false;
	CircleCollider2D col;
	private CircleCollider2D trigger;
	// Use this for initialization
	void Start () {
		col = (from x in GetComponents<CircleCollider2D> ()
			where x.isTrigger
			select x).First ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E) && Vector2.Distance(MovePlayer.Instance.currPlayer.transform.position,
				transform.position) <= col.radius * transform.localScale.x + MovePlayer.Instance.radius)
		{
            
            Inventory.Instance.addItem(this);
            //TODO Store the item
		}
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject == MovePlayer.Instance.currPlayer.gameObject){
            storable = true;

        }

    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject == MovePlayer.Instance.currPlayer.gameObject){            
            storable = false;

        }

    }
}
