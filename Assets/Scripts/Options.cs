using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject player;
    public MainMenu mainMenu;
    public ConfigureControls configureControls;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
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
    public void SpawnOptions()
    {
        gameObject.SetActive(true);
    }
    public void DisableOptions()
    {
        gameObject.SetActive(false);
    }
    public void ReturnToMenu()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            pauseMenu.SpawnPauseMenu();
            gameObject.SetActive(false);
        }
        else
        {
            mainMenu.BackToMainMenu();
            gameObject.SetActive(false);
        }
    }
    public void ToConfigureControls()
    {
        configureControls.SpawnControls();
        gameObject.SetActive(false);
    }
}
