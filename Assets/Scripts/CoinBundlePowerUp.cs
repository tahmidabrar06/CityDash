using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinBundlePowerUp : MonoBehaviour
{
    private GameObject player;
    public int coinValue;
    public int coinBundleValue;
    public Collider objectCollider;
    private float overlapRadius = 1.1f;
    private GameObject sfx;
    public AudioClip coinBundleSFX;

    void Start()
    {
        sfx = GameObject.Find("InGame-SFX");
        player = GameObject.FindGameObjectWithTag("Player");
        objectCollider = gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        if (SceneManager.GetSceneByName("InGame").isLoaded)
        if (IsOverlappingOtherCollider())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinValue = (PlayerPrefs.GetInt("CoinBundleLevel") * 50) + 50;
            player.GetComponent<Movement>().coinsCollected += coinValue;
            player.GetComponent<Movement>().coinBundlePickedUp = true;
            gameObject.SetActive(false);
            AudioSource aud = sfx.GetComponent<AudioSource>();
            aud.PlayOneShot(coinBundleSFX);
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
