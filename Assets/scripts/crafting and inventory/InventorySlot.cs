
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    Item item;
    public Image icon;
    public Text conter;


    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        conter.text = item.count.ToString();
        conter.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        conter.enabled = false;
    }
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
    public Item getItem()
    {
        return item;
    }
}
