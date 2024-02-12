using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private TMP_Dropdown resolutionsDropdown;

    private Resolution[] resolutions;

    List<string> resolutionsName = new();

    private void Start()
    {
        SetResolutionsInArrayAndDropdown();
    }

    private void SetResolutionsInArrayAndDropdown()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        var currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            var resolutionName = resolutions[i].width + " x " + resolutions[i].height;
            
            resolutionsName.Add(resolutionName);

            if(resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height) currentResolutionIndex = i;
        }

        resolutionsDropdown.AddOptions(resolutionsName);
        resolutionsDropdown.value = currentResolutionIndex;

        resolutionsDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        var selectedResolution = resolutions[resolutionIndex];

        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }

    public void HideSettingsView()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
