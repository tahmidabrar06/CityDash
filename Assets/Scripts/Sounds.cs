using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sounds: MonoBehaviour
{
    public Options options;
    public GameObject player;
    void Start()
    {
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
    public void SpawnOptions()
    {
        options.SpawnOptions();
        gameObject.SetActive(false);
    }
    public void SpawnSound()
    {
        gameObject.SetActive(true);
        options.DisableOptions();
    }
}
