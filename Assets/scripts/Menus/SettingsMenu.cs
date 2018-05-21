using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> res = new List<string>();

        int currentIndex = 0;

        for (int i = 0; i< resolutions.Length; i++)
        {
            string r = resolutions[i].width + "x" + resolutions[i].height;
            res.Add(r);
            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }

        resolutionDropdown.AddOptions(res);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }

}
