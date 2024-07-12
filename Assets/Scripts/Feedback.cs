using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{
    public MainMenu MainMenu;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReturnToMainMenu()
    {
        MainMenu.BackToMainMenu();
        gameObject.SetActive(false);
    }
    public void SpawnFeedback()
    {
        gameObject.SetActive(true);
    }
}
