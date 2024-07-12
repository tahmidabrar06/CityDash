using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinMultPowerUpIcon : MonoBehaviour
{
    public Image Timer;
    public float countdownTime;
    public float maxTime;
    public GameObject player;
    public bool isDead;
    private int upgradeLevel;
    public Image[] multiplierNumber;
    public GameObject imgHolder;

    private void Start()
    {
        foreach (Image img in multiplierNumber)
        {
            img.enabled = false;
        }
        imgHolder.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        countdownTime = PlayerPrefs.GetInt("CoinMultiplierDuraLevel") * 10 + 10;
        maxTime = PlayerPrefs.GetInt("CoinMultiplierDuraLevel") * 10 + 10;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        upgradeLevel = PlayerPrefs.GetInt("CoinMultiplierEffLevel");
        isDead = player.GetComponent<Movement>().isDead;
        StartCountdown();
        ColorAndFillChanger();
    }

    void ColorAndFillChanger()
    {
        Color color = Color.Lerp(Color.red, Color.green, (countdownTime / maxTime));
        Timer.color = color;
        float fillAmount = Mathf.Lerp(0f, 1f, (countdownTime / maxTime));
        Timer.fillAmount = fillAmount;
    }

    private void StartCountdown()
    {
        countdownTime -= 1 * Time.deltaTime;
        if (countdownTime <= 0f)
        {
            
            gameObject.SetActive(false);
            countdownTime = 0f;
        }
    }

    public void EnableIcon()
    {
        if (isDead == false)
        {
            imgHolder.SetActive(true);
            multiplierNumber[upgradeLevel].enabled = true;
            gameObject.SetActive(true);
        }
        else
        {
            foreach (Image img in multiplierNumber)
            {
                imgHolder.SetActive(false);
                img.enabled = false;
            }
            gameObject.SetActive(false);
        }
    }

    public void DisableIcon()
    {
        countdownTime = PlayerPrefs.GetInt("CoinMultiplierDuraLevel") * 10 + 10;
        imgHolder.SetActive(false);
        gameObject.SetActive(false);
    }
}
