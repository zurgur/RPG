using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject slime;
    public GameObject skelington;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;



    // Use this for initialization
    void Start () {
        if (GameManeger.instance.Liberated)
        {
            NPC();
        }
        else
        {
		    for(int i = 0; i <= 5; i++)
            {
                GameObject o = Instantiate(slime, transform.position, Quaternion.identity);
                o.transform.parent = this.transform;
            }
            for (int i = 0; i <= 5; i++)
            {
                GameObject o = Instantiate(skelington, transform.position, Quaternion.identity);
                o.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (transform.childCount == 0)
        {
            GameManeger.instance.Liberated = true;
            NPC();
        }
    }
    private void NPC()
    {
        
        GameObject o = Instantiate(npc1, transform.position, transform.rotation);
        o.transform.parent = this.transform;
        o = Instantiate(npc2, transform.position + new Vector3(0,5,0), transform.rotation);
        o.transform.parent = this.transform;
        o = Instantiate(npc3, transform.position - new Vector3(0,5, 0), transform.rotation);
        o.transform.parent = this.transform;

    }
}
