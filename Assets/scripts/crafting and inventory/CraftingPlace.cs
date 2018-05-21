using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPlace : MonoBehaviour {

    public GameObject craft;
    public GameObject inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            craft.SetActive(true);
            inventory.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        craft.SetActive(false);
        inventory.SetActive(false);
    }

}
