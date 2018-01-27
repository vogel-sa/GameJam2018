using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	
	public Storeable item;

	public Sprite itemImage;

	[SerializeField]
	private Vector2 offset = Vector2.zero; // Where to place in relation to player?

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
	public void addItem(Storeable toAdd)
	{
        
		item = toAdd;
        SpriteRenderer rend;
        if(rend = toAdd.GetComponent<SpriteRenderer>())
            itemImage = rend.sprite;
	}

    public void removeItem()
    {

        
		if(!Physics2D.CircleCast((Vector2)MovePlayer.Instance.currPlayer.transform.position + offset,
			item.GetComponent<CircleCollider2D>().radius,
			Vector2.zero,
			0f,
			LayerMask.GetMask("Wall")))
		{
			item.gameObject.SetActive(true);
        	item.gameObject.transform.position = MovePlayer.Instance.currPlayer.transform.position;
        	item = null;
		}

    }
}
