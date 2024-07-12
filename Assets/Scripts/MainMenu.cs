using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Options options;
    public ShopMenu shopMenu;
    public TMP_Text highScoreText;
    public VideoSettings videoSettings;
    public TMP_Text coins;
    public Feedback feedback;
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality", 3));
        highScoreText.text = "Highscore : " + PlayerPrefs.GetInt("HighScore");
        shopMenu.LoadPrices();
        shopMenu.LoadUpgrades();
        shopMenu.DefaultUpgradeLevels();
    }

    public void ToInGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void DeleteHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Options()
    {
        options.SpawnOptions();
        gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        gameObject.SetActive(true);
    }
    public void ToShop()
    {
        shopMenu.SpawnShopMenu();
        gameObject.SetActive(false);
    }
    public void ToFeedback()
    {
        feedback.SpawnFeedback();
        gameObject.SetActive(false);
    }
}
