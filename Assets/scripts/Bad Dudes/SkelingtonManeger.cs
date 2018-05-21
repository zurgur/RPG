using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelingtonManeger : MonoBehaviour {

    private Rigidbody2D myRigedBoddy;

    private float spawnDelayCounter;        // The amount of time between each spawn.

    [SerializeField]
    private float spawnDelay;       // The amount of time before spawning starts.

    [SerializeField]
    private GameObject arrow;


    [SerializeField]
    private int maxDistance;

    [SerializeField]
    private Transform target;

    private Transform myTransform;
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveDierction;
    private float moveConter;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private GameObject aim;
    private int currenthp = 10;

    [SerializeField]
    private GameObject bone;

    void Awake () {
        myTransform = transform;
        myRigedBoddy = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject stop = GameObject.FindGameObjectWithTag("Player");
        moveDierction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
        target = stop.transform;
        spawnDelayCounter = spawnDelay;
        moveConter = moveTime;
    }

    void Update()
    {
        moveConter -= Time.deltaTime;
        if (Vector3.Distance(target.position, myTransform.position) < maxDistance)
        {
            spawnDelayCounter -= Time.deltaTime;
            Quaternion rot = Quaternion.LookRotation(target.position - transform.position, Vector3.forward);

            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
            myRigedBoddy.angularVelocity = 0;
            if (spawnDelayCounter <= 0)
            {
                Instantiate(arrow, gun.position, myTransform.rotation);
                spawnDelayCounter = spawnDelay;
            }
            if (moveConter <= 0)
            {
                if (Vector3.Distance(target.position, myTransform.position) < (maxDistance * 0.25f))
                {
                    moveDierction = new Vector3((target.position - myTransform.position).x * moveSpeed,
                     (myTransform.position - target.position).y * moveSpeed, 0f);
                    moveConter = moveTime;
                }
                else
                {
                    moveDierction = new Vector3((target.position - myTransform.position).x * -moveSpeed,
                     (myTransform.position - target.position).y * -moveSpeed, 0f);
                    moveConter = moveTime;
                }
                
            }
            Move();
        }
        else
        {
            if (moveConter <= 0)
            {
                moveDierction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                moveConter = moveTime;

            }
            Move();
        }
    }
    private void Move()
    {
        myRigedBoddy.velocity = moveDierction;
    }
    public Transform getTargetPos()
    {
        return aim.transform;
    }
    public void damageEnemy(int i)
    {
        currenthp -= i;
        if (currenthp <= 0)
        {

            int cont = Random.Range(0, 4);
            for (int j = 0; j <= cont; j++)
            {
                Instantiate(bone, transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0), Quaternion.identity);
            }
            GameManeger.instance.SkellingtonsKills = 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<playerStats>().addExp(10);
            FindObjectOfType<AudioManager>().play("SkelingtonDeath");

        }
        else
        {
            FindObjectOfType<AudioManager>().play("SkelingtionHit");
        }
    }
}
