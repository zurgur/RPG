using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NPCtriger : MonoBehaviour {

    public string carName;
    public Dialouge dialouge;
    public Dialouge questcomprete;
    public Dialouge questInprogress;
    public Sprite pofile;
    public int qouestCont;
    public string qouestType;
    public string unlocks = "nothing";


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            QouestOver();
            if (PlayerPrefs.GetInt(carName) == 0)
            {
                Debug.Log(dialouge);
                FindObjectOfType<DialougeManeger>().StartDialogue(dialouge, pofile);
                FindObjectOfType<RPGplayer>().setTalking(true);
            }
            else if(PlayerPrefs.GetInt(carName) == 1)
            {

                FindObjectOfType<DialougeManeger>().StartDialogue(questInprogress, pofile);
                FindObjectOfType<RPGplayer>().setTalking(true);
            }
            else if(PlayerPrefs.GetInt(carName) == 2)
            {
                FindObjectOfType<DialougeManeger>().StartDialogue(questcomprete, pofile);
                FindObjectOfType<RPGplayer>().setTalking(true);
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<DialougeManeger>().EndDialoge();
            FindObjectOfType<RPGplayer>().setTalking(false);
            Debug.Log("bæ");
            if (PlayerPrefs.GetInt(carName) == 0)
            {
                PlayerPrefs.SetInt(carName, 1);
            } else if (PlayerPrefs.GetInt(carName) == 2)
            {
                PlayerPrefs.SetInt(carName, 3);
                FindObjectOfType<playerStats>().addExp(10);
                FindObjectOfType<RPGplayer>().GetUnlock(unlocks);
                GetComponent<BoxCollider2D>().enabled = false;
            }

        }
    }
    public void QouestOver()
    {
        switch (qouestType)
        {
            case "slime":
                if (((GameManeger.instance.SlimeKills) >= qouestCont) && (PlayerPrefs.GetInt(carName) != 3)) PlayerPrefs.SetInt(carName, 2);
                break;
            case "fidla":
                if (((GameManeger.instance.Fidla) >= qouestCont) && (PlayerPrefs.GetInt(carName) != 3)) {
                    PlayerPrefs.SetInt(carName, 2);
                    GameManeger.instance.Fidla = -1;
                }
                break;
            case "craft":
                Debug.Log("crafting");
                if ((GameManeger.instance.Fertilizer >= qouestCont) && (PlayerPrefs.GetInt(carName) != 3))
                {
                    GameManeger.instance.Fertilizer = -1;
                    PlayerPrefs.SetInt(carName, 2);
                }
                break;
            default:
                Debug.Log("no such type");
                break;
        }
    }
}
