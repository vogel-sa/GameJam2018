using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
    public GameObject item;
	public Sprite itemImage;
    private static Inventory _instance;
    public static Inventory Instance
    {
        get
        {
            if (!_instance && !(_instance = FindObjectOfType<Inventory>()))
            {
                _instance = new GameObject().AddComponent<Inventory>();
            }
            return _instance;
        }
    }
	//Adds the item to the inventory, if the inventory is not empty, return the item that was in the inventory
    public void addItem(GameObject toAdd)
	{
        
		item = toAdd;
        SpriteRenderer rend;
        if(rend = toAdd.GetComponent<SpriteRenderer>())
            itemImage = rend.sprite;
	}

    public void removeItem()
    {

        item.SetActive(true);
        if()
        item.gameObject.transform.position = MovePlayer.Instance.currPlayer.transform.position;
        item = null;

    }
}
