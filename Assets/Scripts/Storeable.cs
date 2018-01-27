using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Storeable : MonoBehaviour
{
    bool storable = false;
	// Use this for initialization
	void Start () {
        GetComponent<Collider2D>().isTrigger = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.E)){
            gameObject.SetActive(false);
            Inventory.Instance.addItem(gameObject);
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
