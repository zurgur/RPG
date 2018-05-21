using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour {
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

    void Start () {
        startPosition = transform;
        
        var t = FindObjectOfType<RPGplayer>().getTargetPos();
        target = new GameObject("new game");
        target.transform.position = t.transform.position;
    }

    // Update is called once per frame
    void Update () {
        // myBoddy.velocity = speed * (myBoddy.velocity.normalized);
        // myBoddy.AddForce(gameObject.transform.up * speed * Time.deltaTime);
        
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition.position, target.transform.position, t);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<SlimeControler>().damageEnemy(hurtBy);
            Instantiate(damageBurst, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "Skelliboi")
        {
            other.gameObject.GetComponent<SkelingtonManeger>().damageEnemy(hurtBy);
            Instantiate(damageBurst, transform.position, transform.rotation);
        }
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {

            Destroy(gameObject);
        }
    }
}
