using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    [SerializeField]
    private int currLvl;

 
    [SerializeField]
    private int[] toLvlPoints;

    [SerializeField]
    private GameObject levelup;

    [SerializeField]
    private Transform player;

    void Start()
    {
        checkExp();
    }

    void checkExp()
    {
        int currExp = FindObjectOfType<GameManeger>().Exp;


        if (currExp >= toLvlPoints[currLvl])
        {
            GetComponent<RPGplayer>().addMaxHelth(10);
            Instantiate(levelup, player.position, player.rotation);
            currLvl++;
            if (currExp >= toLvlPoints[currLvl]) checkExp();
        }

    }


    public void addExp(int exp)
    {
        GameManeger.instance.Exp = exp;
        checkExp();
    }
}
