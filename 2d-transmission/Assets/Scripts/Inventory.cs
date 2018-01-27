using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public const int numItemSlots = 10;
    SpriteRenderer[] itemSprites = new SpriteRenderer[numItemSlots];
    public GameObject[] items = new GameObject[numItemSlots];
    private int currentItemIndex = 0;

    // Add an item to the player's inventory if it is not full
    public void AddItem(GameObject itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemSprites[i] = itemToAdd.GetComponent<SpriteRenderer>();
                itemSprites[i].enabled = true;
                return;
            }
        }
    }

    // Remove the item that the player currently selected
    public void RemoveCurrentItem()
    {
        Destroy(items[currentItemIndex].gameObject);
        items[currentItemIndex] = null;

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
            currentItemIndex = numItemSlots - 1;
        }
        if (currentItemIndex > items.Length - 1)
        {

        }
    }
}

   /* }


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
}*/

