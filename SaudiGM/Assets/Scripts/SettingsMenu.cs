using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resulotionsDropdown;

    public float volume;
    public Slider volSlider;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resulotionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResulotionIndex = 0;

        for (int i =0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResulotionIndex = i;
            }
        }

        resulotionsDropdown.AddOptions(options);
        resulotionsDropdown.value = currentResulotionIndex;
        resulotionsDropdown.RefreshShownValue();
    }
    public void SetVolume(float vol){
        //Debug.Log(volume);
        //volume = volSlider.value;
        audioMixer.SetFloat("Volume", vol);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void SetResulotion(int resulotionIndex)
    {
        Resolution resolution = resolutions[resulotionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
