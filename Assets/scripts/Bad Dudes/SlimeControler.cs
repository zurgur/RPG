using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeControler : MonoBehaviour {

    private Rigidbody2D myRigedBoddy;
    private bool isMoving;
    public float moveSpeed;

    public float timeBetweenMove;
    private float timeBetweenMoveConter;
    public float timeToMove;
    private float timeToMoveConter;

    private Vector3 moveDierction;
    public float timeToRelode;
    private GameObject player;

    [SerializeField]
    private int hp;
    private int currenthp;

    [SerializeField]
    private GameObject ball;

	// Use this for initialization
	void Start () {
        myRigedBoddy = GetComponent<Rigidbody2D>();
        timeBetweenMoveConter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveConter = timeToMove * Random.value;
        currenthp = hp;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isMoving)
        {
            timeToMoveConter -= Time.deltaTime;
            myRigedBoddy.velocity = moveDierction;
            if (timeToMoveConter < 0f)
            {
                timeBetweenMoveConter = timeBetweenMove;
                isMoving = false;
            }
        }
        else
        {
            timeBetweenMoveConter -= Time.deltaTime;
            myRigedBoddy.velocity = Vector2.zero;
            if (timeBetweenMoveConter < 0f)
            {
                FindObjectOfType<AudioManager>().play("SlimeJump");
                isMoving = true;
                timeToMoveConter = timeToMove;

                moveDierction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
	}

    
    public void damageEnemy(int i)
    {
        currenthp -= i;
        if(currenthp <= 0)
        {
            //var killcont = PlayerPrefs.GetInt("slime");
            //killcont++;
            //PlayerPrefs.SetInt("slime", killcont);
            GameManeger.instance.SlimeKills = 1;
            int cont = Random.Range(0, 4);
            for(int j = 0; j <= cont; j++)
            {
                Instantiate(ball, transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0), Quaternion.identity);
            }
            gameObject.SetActive(false);
            FindObjectOfType<playerStats>().addExp(2);
            FindObjectOfType<AudioManager>().play("SlimeDeth");
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<AudioManager>().play("SlimeHit");
        }
    }
}
