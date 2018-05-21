using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeItem : MonoBehaviour {

    public GameObject ingredientOne;
    public GameObject ingredientTwo;
    public Transform itemsParent;

    InventorySlot[] inventorySlots;
    GameManeger inventory;



    public void clickOnItem()
    {
        inventory = GameManeger.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        InventorySlot inventoryOne = (ingredientOne.GetComponentInChildren<InventorySlot>());
        InventorySlot inventoryTwo = (ingredientTwo.GetComponentInChildren<InventorySlot>());
        Item itemOne = inventoryOne.getItem();
        Item itemTwo = inventoryTwo.getItem();
        inventory.Remove(itemOne);
        inventory.Remove(itemTwo);
        Item myItem = itemOne.makes[0];
        inventory.Add(myItem);
        foreach(Transform child in ingredientOne.transform) {
            child.gameObject.SetActive(false);
            DropZone dz = child.GetComponent<DropZone>();
            if (dz)
            {
                dz.myItem = null;
            }
        }
        foreach (Transform child in ingredientTwo.transform)
        {
            child.gameObject.SetActive(false);
            DropZone dz = child.GetComponent<DropZone>();
            if (dz)
            {
                dz.myItem = null;
            }
        }
        this.transform.GetComponent<Button>().interactable = false;
    }
    public void UpdateUI()
    {
        Debug.Log("updating UI");
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventorySlots[i].ClearSlot();
            }

        }
    }

}
