using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RPGplayer : MonoBehaviour {
    
    [SerializeField]
    private float speed;
    private Rigidbody2D myBoddy;
    private bool talking = false;
    public Animator anim;
    public Animator unlock;
    public GameObject unlockOject;
    public Image unlockImage;

    [SerializeField]
    private float respawn;
    private float respawnConter;
    [SerializeField]
    private bool respawning = false;

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int HP;

    [SerializeField]
    private Slider HelthBar;
    [SerializeField]
    private TextMeshProUGUI HPtext;

    public GameObject bullet;
    public Transform myTransform;
    public Transform target;
    private bool gun;

    // private Animator aim;

    void Start()
    {
        // aim = GetComponent<Animator>();
        myBoddy = GetComponent<Rigidbody2D>();
        HP = maxHP;
        respawnConter = respawn;

        gun = GameManeger.instance.Gun != 0;
        HelthBar.maxValue = maxHP;
        HPtext.text = "HP: " + HP;
    }
	
	// Update is called once per frame
	void Update () {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (respawning)
        {
            Debug.Log(respawnConter);
            respawnConter -= Time.deltaTime;
            if(respawnConter <= 0)
            {
                anim.SetBool("deed", false);
                gameObject.SetActive(true);
                respawnConter = respawn;
                respawning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (!talking)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
            myBoddy.angularVelocity = 0;

            float input = Input.GetAxis("Vertical");
            myBoddy.AddForce(gameObject.transform.up * speed * input * Time.deltaTime);
            anim.SetFloat("speed", input);  
            if ((Input.GetMouseButtonDown(1)))
            {
                anim.SetInteger("punch", 1);
                FindObjectOfType<CameraController>().StartShake(0.1f, 0.1f);
            }
            if ((Input.GetMouseButtonUp(1)))
            {
                anim.SetInteger("punch", 0);
            }
            if ((Input.GetMouseButtonDown(0)) && gun)
            {
                Instantiate(bullet, myTransform.position, myTransform.rotation);
            }
        }
    }
    
    public void takeDamage(int dm)
    {
        HP -= dm;
        HelthBar.value = HP;
        HPtext.text = "HP: " + HP;
        if (HP <= 0)
        {
            respawning = true;
            anim.SetBool("deed", true);
            FindObjectOfType<AudioManager>().play("Player Deth");
            // gameObject.SetActive(false);
        }
    }
    public void resetHelth()
    {
        HP = maxHP;
        HelthBar.maxValue = maxHP;
        HelthBar.value = HP;
        HPtext.text = "HP: " + HP;
    }
    public void addMaxHelth(int hp)
    {
        maxHP += hp;
        resetHelth();

    }
    public void setTalking(bool t)
    {
        talking = t;
    }
    public Transform getTargetPos()
    {
        return target;
    }
    public void GetUnlock(String unlocck)
    {
        if (unlocck == "Gun")
        {
            Debug.Log("gun");
            gun = true;
            GameManeger.instance.Gun = 1;
            unlockOject.SetActive(true);
            unlock.SetBool("isOpen", true);
            
        }
        if (unlocck == "Wrench")
        {
            Debug.Log("wrench");
            GameManeger.instance.Wrench = 1;
            unlockOject.SetActive(true);
            unlockImage.sprite = GameManeger.instance.WrenchItem.icon;
            unlock.SetBool("isOpen", true);
        }
        if(unlocck == "hammer")
        {
            Debug.Log("unlocking hammer");
            GameManeger.instance.Hammer = 1;
            unlockOject.SetActive(true);
            unlockImage.sprite = GameManeger.instance.WrenchItem.icon;
            unlock.SetBool("isOpen", true);
        }
    }
}
