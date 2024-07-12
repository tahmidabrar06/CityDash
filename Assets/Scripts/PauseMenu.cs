using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Options options;
    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {
        
    }
    public void SpawnPauseMenu()
    {
        gameObject.SetActive(true);
    }
    public void DesSpawnPauseMenu()
    {
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Options()
    {
        options.SpawnOptions();
        gameObject.SetActive(false);
    }
}
