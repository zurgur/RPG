
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefultItem = false;
    public string type = "wepon";
    public int count = 1;
    public Item[] makes;
    public Item[] partner;
    

    public virtual void Use()
    {

        Debug.Log("Using " + name);
    }
}
