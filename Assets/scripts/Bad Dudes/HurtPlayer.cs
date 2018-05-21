using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    [SerializeField]
    private int damage;
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<RPGplayer>().takeDamage(damage);
        }
    }
}
