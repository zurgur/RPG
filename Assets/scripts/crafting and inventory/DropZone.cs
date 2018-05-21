
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler {

    public Item myItem = null;
    public bool inventory = false;
    public GameObject sibling;
    public GameObject crafring;
    public Image newItemImage;


    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            myItem = eventData.pointerDrag.GetComponent<InventorySlot>().getItem();
            if(myItem != null && myItem.type == "crafing")
            {
                d.parentToReturnTo = this.transform;
                checkeForMatch();
            }
        }
    }
    public Item getItem()
    {
        return myItem;
    }
    private void checkeForMatch()
    {
        InventorySlot invo = sibling.GetComponentInChildren<InventorySlot>();
        if (invo == null) return;

        if(invo.getItem().partner[0] == myItem)
        {
            Item newItem = myItem.makes[0];
            newItemImage.sprite = newItem.icon;
            newItemImage.enabled = true;
            crafring.GetComponent<Button>().interactable = true;
        }

    }

}
