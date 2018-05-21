using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int hurtBy = 5;
    public GameObject damageBurst;
    public Transform hitPoint;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<SlimeControler>().damageEnemy(hurtBy);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }
    }

}
