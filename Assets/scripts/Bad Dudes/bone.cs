using System.Collections;

using UnityEngine;

public class bone : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManeger.instance.Bones = 1;
        Destroy(gameObject);
    }
}
