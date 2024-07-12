using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public MainMenu mainMenu;
    public TMP_Text coins;
    public TMP_Text invincibilityDuraButton;
    public TMP_Text invincibilitySpeedButton;
    public TMP_Text coinMultiplierDuraButton;
    public TMP_Text coinMultiplierEffButton;
    public TMP_Text coinBundleButton;
    private int totalCoins;

    [Header("Invincibility PowerUp Duration")]
    public Image[] invincibilityDurationImages;
    public int invincibilityDurationLevel;
    private int invincibilityDuraUpgradePrice;
    public int IDuraPriceIncrement;

    [Header("Invincibility PowerUp Speed")]
    public Image[] invincibilitySpeedImages;
    public int invincibilitySpeedLevel;
    private int invincibilitySpeedUpgradePrice;
    public int ISpeedPriceIncrement;

    [Header("Coin Multiplier PowerUp Duration")]
    public Image[] coinMultiplierDuraImages;
    public int coinMultiplierDuraLevel;
    private int coinMultiplierDuraUpgradePrice;
    public int cMultiplierDuraPriceIncrement;

    [Header("Coin Multiplier PowerUp Efficiency")]
    public Image[] coinMultiplierEffImages;
    public int coinMultiplierEffLevel;
    private int coinMultiplierEffUpgradePrice;
    public int cMultiplierEffPriceIncrement;

    [Header("Coin Bundle PowerUp")]
    public Image[] coinBundleImages;
    public int coinBundleLevel;
    private int coinBundleUpgradePrice;
    public int cBundlePriceIncrement;

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("CoinsCollected");
        gameObject.SetActive(false);
        LoadUpgrades();
        LoadPrices();
    }

    void Update()
    {
        UpdateText();
    }
    public void SpawnShopMenu()
    {
        gameObject.SetActive(true);
    }
    public void ReturnToMenu()
    {
        mainMenu.BackToMainMenu();
        gameObject.SetActive(false);
    }
    public void InvincibilityDuraUpgrade()
    {
        if(invincibilityDurationLevel < 5 && totalCoins >= invincibilityDuraUpgradePrice)
        {
            invincibilityDurationLevel += 1;
            Image image;
            image = invincibilityDurationImages[invincibilityDurationLevel - 1];
            image.enabled = false;
            PlayerPrefs.SetInt("InvincibilityDuraLevel", invincibilityDurationLevel);
            totalCoins -= invincibilityDuraUpgradePrice;
            PlayerPrefs.SetInt("CoinsCollected", totalCoins);
            invincibilityDuraUpgradePrice += IDuraPriceIncrement;
            PlayerPrefs.SetInt("InvincibilityUpgradePrice", invincibilityDuraUpgradePrice);
        }
    }
    public void InvincibilitySpeedUpgrade()
    {
        if (invincibilitySpeedLevel < 5 && totalCoins >= invincibilitySpeedUpgradePrice)
        {
            invincibilitySpeedLevel += 1;
            Image image;
            image = invincibilitySpeedImages[invincibilitySpeedLevel - 1];
            image.enabled = false;
            PlayerPrefs.SetInt("InvincibilitySpeedLevel", invincibilitySpeedLevel);
            totalCoins -= invincibilitySpeedUpgradePrice;
            PlayerPrefs.SetInt("CoinsCollected", totalCoins);
            invincibilitySpeedUpgradePrice += ISpeedPriceIncrement;
            PlayerPrefs.SetInt("InvincibilitySpeedUpgradePrice", invincibilitySpeedUpgradePrice);
        }
    }
    public void CoinMultiplierDuraUpgrade()
    {
        if (coinMultiplierDuraLevel < 5 && totalCoins >= coinMultiplierDuraUpgradePrice)
        {
            coinMultiplierDuraLevel += 1;
            Image image;
            image = coinMultiplierDuraImages[coinMultiplierDuraLevel - 1];
            image.enabled = false;
            PlayerPrefs.SetInt("CoinMultiplierDuraLevel", coinMultiplierDuraLevel);
            totalCoins -= coinMultiplierDuraUpgradePrice;
            PlayerPrefs.SetInt("CoinsCollected", totalCoins);
            coinMultiplierDuraUpgradePrice += cMultiplierDuraPriceIncrement;
            PlayerPrefs.SetInt("CoinMultiplierDuraUpgradePrice", coinMultiplierDuraUpgradePrice);
        }
    }
    public void CoinMultiplierEffUpgrade()
    {
        if (coinMultiplierEffLevel < 5 && totalCoins >= coinMultiplierEffUpgradePrice)
        {
            coinMultiplierEffLevel += 1;
            Image image;
            image = coinMultiplierEffImages[coinMultiplierEffLevel - 1];
            image.enabled = false;
            PlayerPrefs.SetInt("CoinMultiplierEffLevel", coinMultiplierEffLevel);
            totalCoins -= coinMultiplierEffUpgradePrice;
            PlayerPrefs.SetInt("CoinsCollected", totalCoins);
            coinMultiplierEffUpgradePrice += cMultiplierEffPriceIncrement;
            PlayerPrefs.SetInt("CoinMultiplierEffUpgradePrice", coinMultiplierEffUpgradePrice);
        }
    }
    public void CoinBundleUpgrade()
    {
        if (coinBundleLevel < 5 && totalCoins >= coinBundleUpgradePrice)
        {
            coinBundleLevel += 1;
            Image image;
            image = coinBundleImages[coinBundleLevel - 1];
            image.enabled = false;
            PlayerPrefs.SetInt("CoinBundleLevel", coinBundleLevel);
            totalCoins -= coinBundleUpgradePrice;
            PlayerPrefs.SetInt("CoinsCollected", totalCoins);
            coinBundleUpgradePrice += cBundlePriceIncrement;
            PlayerPrefs.SetInt("CoinBundleUpgradePrice", coinBundleUpgradePrice);
        }
    }
    public void LoadUpgrades()
    {
        invincibilityDurationLevel = PlayerPrefs.GetInt("InvincibilityDuraLevel", invincibilityDurationLevel);
        for (int i = 0; i < invincibilityDurationLevel; i++)
        {
            if (i < invincibilityDurationLevel)
            {
                invincibilityDurationImages[i].enabled = false;
            }
        }
        invincibilitySpeedLevel = PlayerPrefs.GetInt("InvincibilitySpeedLevel", invincibilitySpeedLevel);
        for (int i = 0; i < invincibilitySpeedLevel; i++)
        {
            if (i < invincibilitySpeedLevel)
            {
                invincibilitySpeedImages[i].enabled = false;
            }
        }
        coinMultiplierDuraLevel = PlayerPrefs.GetInt("CoinMultiplierDuraLevel", coinMultiplierDuraLevel);
        for (int i = 0; i < coinMultiplierDuraLevel; i++)
        {
            if (i < coinMultiplierDuraLevel)
            {
                coinMultiplierDuraImages[i].enabled = false;
            }
        }
        coinMultiplierEffLevel = PlayerPrefs.GetInt("CoinMultiplierEffLevel", coinMultiplierEffLevel);
        for (int i = 0; i < coinMultiplierEffLevel; i++)
        {
            if (i < coinMultiplierEffLevel)
            {
                coinMultiplierEffImages[i].enabled = false;
            }
        }
        coinBundleLevel = PlayerPrefs.GetInt("CoinBundleLevel", coinBundleLevel);
        for (int i = 0; i < coinBundleLevel; i++)
        {
            if (i < coinBundleLevel)
            {
                coinBundleImages[i].enabled = false;
            }
        }
    }
    public void LoadPrices()
    {
        if (PlayerPrefs.HasKey("InvincibilityUpgradePrice"))
        {
            invincibilityDuraUpgradePrice = PlayerPrefs.GetInt("InvincibilityUpgradePrice");
        }
        else
        {
            invincibilityDuraUpgradePrice = IDuraPriceIncrement;
            PlayerPrefs.SetInt("InvincibilityUpgradePrice", invincibilityDuraUpgradePrice);
        }
        if (PlayerPrefs.HasKey("InvincibilitySpeedUpgradePrice"))
        {
            invincibilitySpeedUpgradePrice = PlayerPrefs.GetInt("InvincibilitySpeedUpgradePrice");
        }
        else
        {
            invincibilitySpeedUpgradePrice = ISpeedPriceIncrement;
            PlayerPrefs.SetInt("InvincibilitySpeedUpgradePrice", invincibilitySpeedUpgradePrice);
        }
        if (PlayerPrefs.HasKey("CoinMultiplierDuraUpgradePrice"))
        {
            coinMultiplierDuraUpgradePrice = PlayerPrefs.GetInt("CoinMultiplierDuraUpgradePrice");
        }
        else
        {
            coinMultiplierDuraUpgradePrice = cMultiplierDuraPriceIncrement;
            PlayerPrefs.SetInt("CoinMultiplierDuraUpgradePrice", coinMultiplierDuraUpgradePrice);
        }
        if (PlayerPrefs.HasKey("CoinMultiplierEffUpgradePrice"))
        {
            coinMultiplierEffUpgradePrice = PlayerPrefs.GetInt("CoinMultiplierEffUpgradePrice");
        }
        else
        {
            coinMultiplierEffUpgradePrice = cMultiplierEffPriceIncrement;
            PlayerPrefs.SetInt("CoinMultiplierEffUpgradePrice", coinMultiplierEffUpgradePrice);
        }
        if (PlayerPrefs.HasKey("CoinBundleUpgradePrice"))
        {
            coinBundleUpgradePrice = PlayerPrefs.GetInt("CoinBundleUpgradePrice");
        }
        else
        {
            coinBundleUpgradePrice = cBundlePriceIncrement;
            PlayerPrefs.SetInt("CoinBundleUpgradePrice", coinBundleUpgradePrice);
        }

    }
    public void DefaultUpgradeLevels()
    {
        if (PlayerPrefs.HasKey("InvincibilityDuraLevel"))
        {
            invincibilityDurationLevel = PlayerPrefs.GetInt("InvincibilityDuraLevel");
        }
        else
        {
            invincibilityDurationLevel = 0;
            PlayerPrefs.SetInt("InvincibilityDuraLevel", invincibilityDurationLevel);
        }

        if (PlayerPrefs.HasKey("InvincibilitySpeedLevel"))
        {
            invincibilitySpeedLevel = PlayerPrefs.GetInt("InvincibilitySpeedLevel");
        }
        else
        {
            invincibilitySpeedLevel = 0;
            PlayerPrefs.SetInt("InvincibilitySpeedLevel", invincibilitySpeedLevel);
        }

        if (PlayerPrefs.HasKey("CoinMultiplierDuraLevel"))
        {
            coinMultiplierDuraLevel = PlayerPrefs.GetInt("CoinMultiplierDuraLevel");
        }
        else
        {
            coinMultiplierDuraLevel = 0;
            PlayerPrefs.SetInt("CoinMultiplierDuraLevel", coinMultiplierDuraLevel);
        }

        if (PlayerPrefs.HasKey("CoinMultiplierEffLevel"))
        {
            coinMultiplierEffLevel = PlayerPrefs.GetInt("CoinMultiplierEffLevel");
        }
        else
        {
            coinMultiplierEffLevel = 0;
            PlayerPrefs.SetInt("CoinMultiplierEffLevel", coinMultiplierEffLevel);
        }
        if (PlayerPrefs.HasKey("CoinBundleLevel"))
        {
            coinBundleLevel = PlayerPrefs.GetInt("CoinBundleLevel");
        }
        else
        {
            coinBundleLevel = 0;
            PlayerPrefs.SetInt("CoinBundleLevel", coinBundleLevel);
        }
    }
    void UpdateText()
    {
        coins.text = PlayerPrefs.GetInt("CoinsCollected").ToString();
        if (PlayerPrefs.GetInt("InvincibilityDuraLevel") < 5)
        {
            invincibilityDuraButton.text = PlayerPrefs.GetInt("InvincibilityUpgradePrice").ToString();
        }
        else
        {
            invincibilityDuraButton.text = "Maxed";
        }

        if (PlayerPrefs.GetInt("InvincibilitySpeedLevel") < 5)
        {
            invincibilitySpeedButton.text = PlayerPrefs.GetInt("InvincibilitySpeedUpgradePrice").ToString();
        }
        else
        {
            invincibilitySpeedButton.text = "Maxed";
        }

        if (PlayerPrefs.GetInt("CoinMultiplierDuraLevel") < 5)
        {
            coinMultiplierDuraButton.text = PlayerPrefs.GetInt("CoinMultiplierDuraUpgradePrice").ToString();
        }
        else
        {
            coinMultiplierDuraButton.text = "Maxed";
        }

        if (PlayerPrefs.GetInt("CoinMultiplierEffLevel") < 5)
        {
            coinMultiplierEffButton.text = PlayerPrefs.GetInt("CoinMultiplierEffUpgradePrice").ToString();
        }
        else
        {
            coinMultiplierEffButton.text = "Maxed";
        }

        if (PlayerPrefs.GetInt("CoinBundleLevel") < 5)
        {
            coinBundleButton.text = PlayerPrefs.GetInt("CoinBundleUpgradePrice").ToString();
        }
        else
        {
            coinBundleButton.text = "Maxed";
        }
    }

}
