using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Invincibility PowerUp")]
    public int invincibilityDura;
    public float invincibilityTimer = 0f;
    public int boostSpeed;
    public int boostMoveSpeed;
    private float runSpeed;
    private float moveSpeed;
    public PowerUpIcon powerUpIcon;
    private bool gotRunspeed = false;

    [Header("Coin Multiplier PowerUp")]
    public int coinMultiDura;
    public float coinMultiTimer = 0f;
    public CoinMultPowerUpIcon coinMultPowerUpIcon;
    public GameObject coinMultiplierEffect;
    private GameObject powerUpMusic;
    private GameObject inGameMusic;
    
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpMusic = GameObject.Find("Music-InPowerUp");
        inGameMusic = GameObject.Find("Music-InGame");
        powerUpMusic.GetComponent<AudioSource>().mute = true;
        runSpeed = player.GetComponent<Movement>().runSpeed;
        moveSpeed = player.GetComponent<Movement>().moveSpeed;
        coinMultiplierEffect.SetActive(false);
        LoadPowerUpValues();
        
    }
    void Update()
    {
        InvincibilityPowerUp();
        CoinMultiplierPowerUp();
    }
    void InvincibilityPowerUp()
    {
        if (player.GetComponent<Movement>().invincibilityPowerUp == true && player.GetComponent<Movement>().isDead == false)
        {
            if(gotRunspeed == false)
            {
                runSpeed = player.GetComponent<Movement>().runSpeed;
                gotRunspeed = true;
            }
            invincibilityTimer += Time.deltaTime;
            float tempSpeed = runSpeed + boostSpeed;
            player.GetComponent<Movement>().runSpeed = tempSpeed;
            player.GetComponent<Movement>().moveSpeed = boostMoveSpeed;
            powerUpIcon.EnableIcon();
            powerUpMusic.GetComponent<AudioSource>().mute = false;
            inGameMusic.GetComponent<AudioSource>().mute = true;
            if (invincibilityTimer >= invincibilityDura)
            {
                invincibilityTimer = 0f;
                player.GetComponent<Movement>().invincibilityPowerUp = false;
                player.GetComponent<Movement>().runSpeed = runSpeed;
                player.GetComponent<Movement>().moveSpeed = moveSpeed;
                powerUpMusic.GetComponent<AudioSource>().mute = true;
                inGameMusic.GetComponent<AudioSource>().mute = false;
                powerUpIcon.DisableIcon();
                gotRunspeed = false;
            }
        }
    }
    void CoinMultiplierPowerUp()
    {
        if (player.GetComponent<Movement>().coinMultiplierPowerUp == true)
        {
            coinMultiTimer += Time.deltaTime;
            coinMultPowerUpIcon.EnableIcon();
            coinMultiplierEffect.SetActive(true);
            if (coinMultiTimer >= coinMultiDura)
            {
                coinMultiTimer = 0f;
                player.GetComponent<Movement>().coinMultiplierPowerUp = false;
                coinMultPowerUpIcon.DisableIcon();
                coinMultiplierEffect.SetActive(false);
            }
        }
    }
    void LoadPowerUpValues()
    {
        int duraUpgradeLevel = PlayerPrefs.GetInt("InvincibilityDuraLevel", -1);
        if (duraUpgradeLevel >= 0 && duraUpgradeLevel <= 5)
        {
            invincibilityDura = (duraUpgradeLevel * 5) + 5;
        }
        else
        {
            invincibilityDura = 5;
        }
        int speedUpgradeLevel = PlayerPrefs.GetInt("InvincibilitySpeedLevel", -1);
        if (speedUpgradeLevel >= 0 && speedUpgradeLevel <= 5)
        {
            boostSpeed = (speedUpgradeLevel * 10) + 15;
        }
        else
        {
            boostSpeed = 15;
        }
        int coinMultiplierDuraUpgradeLevel = PlayerPrefs.GetInt("CoinMultiplierDuraLevel", -1);
        if (coinMultiplierDuraUpgradeLevel >= 0 && coinMultiplierDuraUpgradeLevel <= 5)
        {
            coinMultiDura = (coinMultiplierDuraUpgradeLevel * 10) + 10;
        }
        else
        {
            coinMultiDura = 10;
        }
    }
}
