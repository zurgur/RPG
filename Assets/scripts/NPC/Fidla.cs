
using UnityEngine;

public class Fidla : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        GameManeger.instance.Fidla = 1;
        Destroy(gameObject);
    }
}
