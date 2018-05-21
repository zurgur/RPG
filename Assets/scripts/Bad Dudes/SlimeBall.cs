using UnityEngine;

public class SlimeBall : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D other)
    {
        GameManeger.instance.Slime = 1;
        Destroy(gameObject);
    }



}
