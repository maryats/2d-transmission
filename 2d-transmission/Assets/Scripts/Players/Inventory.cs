using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {
	
	public static int numItemSlots = 3;
	SpriteRenderer[] itemSprites = new SpriteRenderer[numItemSlots];
	public AttackUpItem[] items = new AttackUpItem[numItemSlots];
    private int currentItemIndex = 0;

	// Add an item to the player's inventory if it is not full
	public void AddItem(AttackUpItem itemToAdd)
    {
		for (int i = 0; i < numItemSlots; i++)
        {
			int cur = (currentItemIndex + i) % numItemSlots;
			if (items[cur] == null)
            {
                items[cur]= itemToAdd;
				itemSprites[cur] = itemToAdd.GetComponent<SpriteRenderer> ();
				itemSprites[cur].enabled = true;
                return;
            }
        }
    }

	// Remove the item that the player currently selected
	public void RemoveCurrentItem()
    {
		Destroy (items [currentItemIndex].gameObject);
		items [currentItemIndex] = null;
    }
		

    // cycles through inventory, probably moving this to player controller
    public void toggleItems()
    {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            currentItemIndex--;

        }
		if (Input.GetKeyDown(KeyCode.E))
        {
            currentItemIndex++;
        }

		if (currentItemIndex < 0)
		{
			currentItemIndex = numItemSlots-1;
		}
		else if (currentItemIndex >= numItemSlots)
        {
            currentItemIndex = 0;
        }

    }

	public bool isFull() {
		int counter = 0;
		for (int i = 0; i < numItemSlots; i++) {
			if (items [i] != null) {
				counter++;
			}
		}
		return counter == numItemSlots;
	}
}
