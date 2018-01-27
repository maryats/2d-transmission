/*using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public int currentItem;
    public const int numItemSlots = 10;
    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void TransferItem(Item itemToTransfer)
    {
        if (player1.input == transferButton)
        {
            player1.removeItem(itemToTransfer);
            player2.addItem(itemToTransfer);
        }
    }

    // cycles through inventory, probably moving this to player controller
    public void toggleItems()
    {
        if (player.input == leftTrigger)        
        {
            currentItem--;
        }
        if (player.input == rightTrigger)
        {
            currentItem++;
        }
        if (currentItem > items.Length - 1)
        {
            currentItem = 0;
        }
        if (currentItem < 0)
        {
            currentItem = items.Length - 1;
        }
<<<<<<< HEAD
    }
}
=======
    }*/
>>>>>>> willbridges
