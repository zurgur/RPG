using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManeger : MonoBehaviour {

    public Queue<string> sentenses;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialougeText;
    public Image profile;
    public GameObject dialogHolder;

    public Animator anim;

    void Start()
    {
        sentenses = new Queue<string>();
    }
    public void StartDialogue(Dialouge dialouge, Sprite image)
    {
        profile.sprite = image;
        dialogHolder.SetActive(true);
        anim.SetBool("IsOpen", true);

        nameText.text = dialouge.name;

        sentenses.Clear();
        
        foreach (string sentences in dialouge.sentenses)
        {
            sentenses.Enqueue(sentences);
        }
        DisplayNextSentense();
    }
    public void DisplayNextSentense()
    {
        Debug.Log(sentenses.Count + "display next");
        if(sentenses.Count <= 0)
        {
            EndDialoge();
            return;
        }
        string sentence = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentense)
    {
        dialougeText.text = "";
        foreach(char str in sentense.ToCharArray())
        {
            dialougeText.text += str;
            yield return null;
        }
    }
    public void EndDialoge()
    {
        anim.SetBool("IsOpen", false);
        FindObjectOfType<RPGplayer>().setTalking(false);
        Debug.Log("End of conversation");
        dialogHolder.SetActive(false);
    }



}
