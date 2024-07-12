using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public CharacterController controller;
    public int driveSpeed;
    private int speed;
    private Vector3 driveDir;
    private bool playerDetected = false;
    private GameObject player;
    private bool isDead;
    public Vector3 initialLocalPosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerDetected == true)
        {
            Drive();
            Stop();
        }
    }
    void Drive()
    {
        driveDir = new Vector3(1, 0, 0);
        speed = driveSpeed;
        controller.Move(driveDir * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }
    void Stop()
    {
        isDead = player.GetComponent<Movement>().isDead;
        if (isDead == true)
        {
            driveSpeed = 0;
        }
    }
    private void StoreInitialLocalPosition()
    {
        initialLocalPosition = gameObject.transform.localPosition;
    }

    private void OnDisable()
    {
        gameObject.transform.localPosition = initialLocalPosition;
        speed = 0;
        playerDetected = false;

    }
    private void OnEnable()
    {
        StoreInitialLocalPosition();
    }
}
