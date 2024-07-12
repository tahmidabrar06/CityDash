using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public GameObject player;
    public GameObject highlightSFX;
    public GameObject selectSFX;
    public GameObject inGameSFX;
    public GameObject MenuMusic;
    public GameObject musicInGame;
    public GameObject musicPowerUp;
    public GameObject musicDeath;

    [Header("Audio Clips")]
    public AudioClip highlightSound;
    public AudioClip coinPickUp;


    [Header("Volume Sliders")]

    public Slider uiSfx;
    public Slider gameSfx;
    public Slider mainMenuMusic;
    public Slider inGameMusic;
    void Start()
    {
        LoadVolumeLevels();
        musicDeath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            if (player.GetComponent<Movement>().inPauseMenu == false)
            {
                Death();
            }
            MenuMusic.GetComponent<AudioSource>().mute = true;
        }
    }
    public void ChangeUISfxVolume()
    {
        highlightSFX.GetComponent<AudioSource>().volume = uiSfx.value;
        selectSFX.GetComponent<AudioSource>().volume = uiSfx.value;
        PlayerPrefs.SetFloat("UI-SFX", uiSfx.value);
    }
    public void PlayHighlightOnClick()
    {
        highlightSFX.GetComponent<AudioSource>().PlayOneShot(highlightSound);
    }
    public void ChangeInGameSFXVolume()
    {
        inGameSFX.GetComponent<AudioSource>().volume = gameSfx.value;
        PlayerPrefs.SetFloat("GameSFX", gameSfx.value);
    }
    public void PlayCoinOnClick()
    {
        inGameSFX.GetComponent<AudioSource>().PlayOneShot(coinPickUp);
    }
    public void ChangeMainMenuMusicVolume()
    {
        MenuMusic.GetComponent<AudioSource>().volume = mainMenuMusic.value;
        PlayerPrefs.SetFloat("MainMenuMusic", mainMenuMusic.value);
    }
    public void ChangeInGameMusicVolume()
    {
        musicInGame.GetComponent<AudioSource>().volume = inGameMusic.value;
        musicPowerUp.GetComponent<AudioSource>().volume = inGameMusic.value;
        musicDeath.GetComponent<AudioSource>().volume = inGameMusic.value;
        PlayerPrefs.SetFloat("InGameMusic", inGameMusic.value);
    }
    void Death()
    {
        if (player.GetComponent<Movement>().inPauseMenu)
        {
            //make some kind of tunnel sound effect
        }
        if (player.GetComponent<Movement>().isDead)
        {
            musicInGame.GetComponent<AudioSource>().mute = true;
            musicPowerUp.GetComponent<AudioSource>().mute = true;
            musicDeath.SetActive(true);
        }
    }
    public void SaveVolumeLevels()
    {
 
        
    }
    public void LoadVolumeLevels()
    {        
        uiSfx.value = PlayerPrefs.GetFloat("UI-SFX", 1);
        gameSfx.value = PlayerPrefs.GetFloat("GameSFX", 1);
        mainMenuMusic.value = PlayerPrefs.GetFloat("MainMenuMusic", 1);
        inGameMusic.value = PlayerPrefs.GetFloat("InGameMusic", 1);
        highlightSFX.GetComponent<AudioSource>().volume = uiSfx.value;
        selectSFX.GetComponent<AudioSource>().volume = uiSfx.value;
        inGameSFX.GetComponent<AudioSource>().volume = gameSfx.value;
        MenuMusic.GetComponent<AudioSource>().volume = mainMenuMusic.value;
        musicInGame.GetComponent<AudioSource>().volume = inGameMusic.value;
        musicPowerUp.GetComponent<AudioSource>().volume = inGameMusic.value;
        musicDeath.GetComponent<AudioSource>().volume = inGameMusic.value;
    }
}
