using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpIcon : MonoBehaviour
{
    public Image Timer;
    public float countdownTime;
    public float maxTime;
    public GameObject player;
    public GameObject icon;
    public bool isDead;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        countdownTime = PlayerPrefs.GetInt("InvincibilityDuraLevel") * 5 + 5;
        maxTime = PlayerPrefs.GetInt("InvincibilityDuraLevel") * 5 + 5;
        icon.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Update()
    {
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
            countdownTime = 0f;
        }
    }

    public void EnableIcon()
    {
        if (isDead == false)
        {
            icon.SetActive(true);
            gameObject.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void DisableIcon()
    {
        countdownTime = PlayerPrefs.GetInt("InvincibilityDuraLevel") * 5 + 5;
        icon.SetActive(false);
        gameObject.SetActive(false);
    }
}
