using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Inventory : MonoBehaviour {
	
	public Storeable item = null;

	public Image itemImage = null;

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
		if (removeItem()) {
			item = toAdd;
			toAdd.gameObject.SetActive(false);
			SpriteRenderer rend;
			if (rend = toAdd.GetComponent<SpriteRenderer> ()) {
				itemImage.sprite = rend.sprite;
				itemImage.color = rend.color;
			}
		}	
	}

	// Returns whether the item was removed successfully, true if no item.
    public bool removeItem()
    {
		if (item == null)
			return true;
		bool ret;

		CircleCollider2D col = (from x in item.GetComponents<CircleCollider2D> ()
		                        where x.isTrigger
		                        select x).First ();

		if(ret = !Physics2D.CircleCast((Vector2)MovePlayer.Instance.currPlayer.transform.position + offset,
			col.radius,
			Vector2.zero,
			0f,
			LayerMask.GetMask("Wall")))
		{
			item.gameObject.SetActive(true);
			item.gameObject.transform.position = MovePlayer.Instance.currPlayer.transform.position + (Vector3)offset;
        	item = null;
			itemImage.color = Color.clear;
		}
		return ret;
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R) && item){
			removeItem ();
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine (MovePlayer.Instance.currPlayer.transform.position,
			MovePlayer.Instance.currPlayer.transform.position + (Vector3)offset);
	}

}
