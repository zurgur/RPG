using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    GameManeger inventory;
    public GameObject inventoryUI;

    InventorySlot[] inventorySlots;

	// Use this for initialization
	public void Start () {
        inventory = GameManeger.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}
    public void UpdateUI()
    {
        Debug.Log("updating UI");
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(i < inventory.items.Count)
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
 