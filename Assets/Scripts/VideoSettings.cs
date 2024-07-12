using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoSettings : MonoBehaviour
{
    public Options options;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreen;
    private GameObject player;
    Resolution[] resolutions;
    void Start()
    {
        player = GameObject.Find("Player");
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", 3);
        GetResolution();
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            if (player.GetComponent<Movement>().inPauseMenu == false)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void SpawnVideoSettings()
    {
        options.DisableOptions();
        gameObject.SetActive(true);
    }
    public void ReturnToOptions()
    {
        options.SpawnOptions();
        gameObject.SetActive(false);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
    }
    public void GetResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
