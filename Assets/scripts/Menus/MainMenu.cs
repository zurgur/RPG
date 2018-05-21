using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(string world)
    {
        SceneManager.LoadScene(world);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quiting");
        Application.Quit();  
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("HubWorld");

    }
}
