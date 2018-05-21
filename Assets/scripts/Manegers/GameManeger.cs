using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour {

    private int slimeKills;
    private int skellingtonsKills;
    private int exp;
    private int slime;
    private int bones;
    private int gold;
    private int fertilizer;
    private int gun;
    private int fidla;
    private int hammer;
    private int wrench;
    private bool liberated;
    public static GameManeger instance;
    [SerializeField]
    public int inventerySize;
    public List<Item> items;
    public Item gunItem;
    public Item slimeItem;
    public Item boneItem;
    public Item fertilizerItem;
    public Item WrenchItem;
    public Item fidlaItem;
    public Item hammerItem;
    Scene scene;



    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (instance != null)
        {
            Debug.LogWarning("trying to make two instances of Gamemaneger");
            return;
        }
        instance = this;
        gun = PlayerPrefs.GetInt(gunItem.name);
        Fidla = PlayerPrefs.GetInt(fidlaItem.name);
        slime = PlayerPrefs.GetInt(slimeItem.name);
        fertilizer = PlayerPrefs.GetInt(fertilizerItem.name);
        bones = PlayerPrefs.GetInt(boneItem.name);
        Gold = PlayerPrefs.GetInt("gold");
        SkellingtonsKills = PlayerPrefs.GetInt("skellingtonsKills");
        SlimeKills = PlayerPrefs.GetInt("slimeKills");
        exp = PlayerPrefs.GetInt("exp");
        wrench = PlayerPrefs.GetInt(WrenchItem.name);
        hammer = PlayerPrefs.GetInt(hammerItem.name);
        Liberated = PlayerPrefs.GetInt(scene.name) != 0;
    }
    void Start()
    {
        StartCoroutine(LateStart(1f));
    }

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;


    public int SlimeKills
    {
        get
        {
            return slimeKills;
        }

        set
        {
            slimeKills += value;
            PlayerPrefs.SetInt("slimeKills", slimeKills);
        }
    }

    public int SkellingtonsKills
    {
        get
        {
            return skellingtonsKills;
        }

        set
        {
            skellingtonsKills += value;
            PlayerPrefs.SetInt("skellingtonsKills", skellingtonsKills);
        }
    }

    public int Slime
    {
        get
        {
            return slime;
        }

        set
        {
            slime += value;
            PlayerPrefs.SetInt(slimeItem.name, slime);
            Add(slimeItem);
        }
    }

    public int Bones
    {
        get
        {
            return bones;
        }

        set
        {
            bones += value;
            PlayerPrefs.SetInt("bones", bones);
            Add(boneItem);
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold += value;
            PlayerPrefs.SetInt("gold", gold);

        }
    }

    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            exp += value;
            PlayerPrefs.SetInt("exp", exp);
        }
    }

    public bool Liberated
    {
        get
        {
            return liberated;
        }

        set
        {
            liberated = value;
            if (liberated)
            {
                PlayerPrefs.SetInt(scene.name, 1);
            }
        }
    }

    public int Gun
    {
        get
        {
            return gun;
        }

        set
        {
            gun = value;
            PlayerPrefs.SetInt("gun", value);
            Add(gunItem);
        }
    }

    public int Fertilizer
    {
        get
        {
            return fertilizer;
        }

        set
        {
            if(value > 0)
            {
                Add(fertilizerItem);
            }
            else
            {
                Remove(fertilizerItem);
            }
        }
    }

    public int Wrench
    {
        get
        {
            return wrench;
        }

        set
        {
            if(value > 0)
            {
                Add(WrenchItem);
            }
            else
            {
                Remove(WrenchItem);
            }
        }
    }

    public int Fidla
    {
        get
        {
            return fidla;
        }

        set
        {
            fidla = value;
            if (value > 0) Add(fidlaItem);
            else { fidlaItem.count = 0; Remove(fidlaItem);  }
        }
    }

    public int Hammer
    {
        get
        {
            return hammer;
        }

        set
        {
            hammer = value;
            if (value > 0) Add(hammerItem);
            else { hammerItem.count = 0; Remove(hammerItem); }
        }
    }

    public bool Add(Item item)
    {
        if (items.Count >= inventerySize)
        {
            return false;
        }
        items.Remove(item);
        PlayerPrefs.SetInt(item.name, (item.count+1));
        item.count += 1;
        items.Add(item);
        if(OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        if(item.count <= 1)
        {
            items.Remove(item);
            PlayerPrefs.SetInt(item.name, 0);
        }
        else
        {
            items.Remove(item);
            int i = item.count - 1;
            print(i);
            PlayerPrefs.SetInt(item.name, i);
            item.count -= 1;
            items.Add(item);
        }
        
        if(OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (gun != 0) Add(gunItem);
        if (bones > 0)
        {
            boneItem.count = bones - 1;
            Add(boneItem);
            boneItem.count += 1;

        }
       
        if (slime > 0)
        {
            slimeItem.count = slime -1;

            Add(slimeItem);

            slimeItem.count += 1;
        }
        
        if (fertilizer > 0)
        {
            fertilizerItem.count = fertilizer -1;

            Add(fertilizerItem);

            fertilizerItem.count += 1;
        }
        if(wrench > 0)
        {
            Add(WrenchItem);
        }
        if(Fidla > 0)
        {
            Add(fidlaItem);
        }
        if(hammer > 0)
        {
            Add(hammerItem);
        }
    }
}
