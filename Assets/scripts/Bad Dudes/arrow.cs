using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
    [SerializeField]
    private float speed;
    // Use this for initialization
    private float t;
    [SerializeField]
    private float timeToReachTarget;

    public int hurtBy = 2;
    public GameObject damageBurst;

    private Transform startPosition;

    private GameObject target;

    void Start()
    {
        startPosition = transform;
        var t = FindObjectOfType<SkelingtonManeger>().getTargetPos();
        target = new GameObject("new game");
        target.transform.position = t.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition.position, target.transform.position, t);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other);
            FindObjectOfType<RPGplayer>().takeDamage(hurtBy);
            Instantiate(damageBurst, transform.position, transform.rotation);
        }
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
