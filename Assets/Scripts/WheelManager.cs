using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WheelManager : MonoBehaviour
{
    public float wheelRotationSpeed;
    private GameObject player;
    private bool isDead;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Stop();
        WheelRotation();
    }
    void WheelRotation()
    {
        transform.Rotate(0, wheelRotationSpeed, 0);
    }
    void Stop()
    {
        if (SceneManager.GetActiveScene().name == "InGame")
        {
            isDead = player.GetComponent<Movement>().isDead;
        }
        if (isDead == true)
        {
            wheelRotationSpeed = 0;
        }
    }
}
