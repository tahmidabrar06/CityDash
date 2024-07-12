using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int scoreToDifficulty1;
    public int scoreToDifficulty2;
    public int difficulty1Speed;
    public int difficulty2Speed;
    public int currentScore;
    private string scoreToString;
    public bool isDead;
    private Transform playerPosZ;
    public TMP_Text score;
    public TMP_Text coinsText;
    public TMP_Text runSpeed;
    public bool difficulty1 = false;
    public bool difficulty2 = false;
    private int coinsCollected;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            if(PlayerPrefs.GetInt("HighScore") < currentScore)
                PlayerPrefs.SetInt("HighScore", currentScore);
            return;
        }
        OnDeath();
        GetScore();
        Difficulty();
        CoinsCollected();
    }
    void GetScore()
    {
        playerPosZ = GameObject.FindGameObjectWithTag("Player").transform;
        currentScore = ((int)playerPosZ.transform.position.z);
        scoreToString = currentScore.ToString();
        score.text = scoreToString;
    }
    void Difficulty()
    {
        float moveSpeed = 0.15f;
        player.GetComponent<Movement>().runSpeed += moveSpeed * Time.deltaTime;
        int runSpeedInt = (int)player.GetComponent<Movement>().runSpeed;
        if(runSpeed != null)
            runSpeed.text = runSpeedInt.ToString();
    }
    void CoinsCollected()
    {
        if(coinsText != null)
        {
            int coins = player.GetComponent<Movement>().coinsCollected;
            coinsText.text = coins.ToString();
        }
    }
    void OnDeath()
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.GetComponent<Movement>().isDead == true)
        {
            isDead = true;
        }   
    }
}
