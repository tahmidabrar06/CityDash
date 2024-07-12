using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConfigureControls : MonoBehaviour
{
    public TMP_Text jump;
    public TMP_Text roll;
    public TMP_Text moveLeft;
    public TMP_Text moveRight;

    public Options options;
    public GameObject player;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode rollKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;

    public Button jumpButton; 
    public Button rollButton;
    public Button moveleftmoveLeftButton;
    public Button moverightmoveLeftButton;
    void Start()
    {
        LoadSettings();
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
    public void SpawnControls()
    {
        gameObject.SetActive(true);
        LoadSettings();

    }
    public void SpawnOptions()
    {
        options.SpawnOptions();
        gameObject.SetActive(false);
    }
    public void OnJumpButtonClicked()
    {
        StartCoroutine(WaitForKeyInput("Jump"));
        jump.text = "Press Any Key";
    }

    public void OnRollButtonClicked()
    {
        StartCoroutine(WaitForKeyInput("Roll"));
        roll.text = "Press Any Key";
    }

    public void OnMoveLeftButtonClicked()
    {
        StartCoroutine(WaitForKeyInput("MoveLeft"));
        moveLeft.text = "Press Any Key";
    }
    public void OnMoveRightButtonClicked()
    {
        StartCoroutine(WaitForKeyInput("MoveRight"));
        moveRight.text = "Press Any Key";
    }

    IEnumerator WaitForKeyInput(string controlName)
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }
        KeyCode newKeyCode = KeyCode.None;
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                newKeyCode = keyCode;
                break;
            }
        }
        if (newKeyCode != KeyCode.None)
        {
            switch (controlName)
            {
                case "Jump":
                    jumpKey = newKeyCode;
                    jump.text = jumpKey.ToString();
                    break;
                case "Roll":
                    rollKey = newKeyCode;
                    roll.text = rollKey.ToString();
                    break;
                case "MoveLeft":
                    moveLeftKey = newKeyCode;
                    moveLeft.text = moveLeftKey.ToString();
                    break;
                case "MoveRight":
                    moveRightKey = newKeyCode;
                    moveRight.text = moveRightKey.ToString();
                    break;
            }
        }

    }
    public void SaveSettings()
    {
        PlayerPrefs.SetString("jumpKey", jumpKey.ToString());
        PlayerPrefs.SetString("rollKey", rollKey.ToString());
        PlayerPrefs.SetString("moveLeftKey", moveLeftKey.ToString());
        PlayerPrefs.SetString("moveRightKey", moveRightKey.ToString());
        PlayerPrefs.Save();
        SpawnOptions();
    }


    public void LoadSettings()
    {
        jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        jump.text = jumpKey.ToString();
        rollKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rollKey", "S"));
        roll.text = rollKey.ToString();
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveLeftKey", "A"));
        moveLeft.text = moveLeftKey.ToString();
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveRightKey", "D"));
        moveRight.text = moveRightKey.ToString();
    }
}
