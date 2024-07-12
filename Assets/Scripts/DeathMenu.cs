using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public bool fade;
    public RawImage deathScreen;
    public float fadeDuration;
    private float alphaValue;
    public GameObject player;
    

    void Start()
    {
        alphaValue = deathScreen.color.a;
        gameObject.SetActive(false);
    }
    void Update()
    {
        fade = player.GetComponent<Movement>().isDead;
        if(fade == true)
        {
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, 0.0f);
            StartCoroutine(FadeInImage());
        }
    }
    public void ToggleEndMenu()
    {
        gameObject.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator FadeInImage()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            alphaValue = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeDuration);
            deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, alphaValue);
            yield return null;
        }
        deathScreen.color = new Color(deathScreen.color.r, deathScreen.color.g, deathScreen.color.b, 1.0f);
    }
}
