using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);

        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
