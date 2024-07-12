using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMultiplierPowerUp : MonoBehaviour
{
    private GameObject player;
    public Collider objectCollider;
    private float overlapRadius = 1.1f;
    public GameObject[] multiplierNumber;
    public int upgradeLevel;
    private bool numberSpawned;
    private GameObject sfx;
    public AudioClip coinMultiplierSFX;
    


    void Start()
    {
        sfx = GameObject.Find("InGame-SFX");
        numberSpawned = false;
        foreach(GameObject obj in multiplierNumber)
        {
            obj.SetActive(false);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        objectCollider = gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        upgradeLevel = PlayerPrefs.GetInt("CoinMultiplierEffLevel");
        if(numberSpawned == false)
        {
            multiplierNumber[upgradeLevel].SetActive(true);
            numberSpawned = true;
        }
        multiplierNumber[upgradeLevel].SetActive(true);
        if (IsOverlappingOtherCollider())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sfx.GetComponent<AudioSource>().PlayOneShot(coinMultiplierSFX);
            player.GetComponent<Movement>().coinMultiplierPowerUp = true;
            gameObject.SetActive(false);
        }

    }
    private bool IsOverlappingOtherCollider()
    {
        Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, overlapRadius);

        foreach (Collider collider in overlappingColliders)
        {
            if (collider != objectCollider && !collider.isTrigger && !(collider.CompareTag("Player")) && !(collider.CompareTag("Movable")) && !(collider.CompareTag("InstaDeath")))
            {
                return true;
            }
        }

        return false;
    }
}
