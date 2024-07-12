using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    private GameObject player;
    public int coinValue;
    public int coinMultiplierValue;
    public Collider objectCollider;
    private float overlapRadius = 1.1f;
    public bool coinMultiplierPowerUp;
    public float rotationSpeed = 100f;
    private Renderer[] coinRenderers;
    private GameObject sfx;
    public AudioClip coinPickUp;

    void Start()
    {
        coinRenderers = GetComponentsInChildren<Renderer>();
        sfx = GameObject.Find("InGame-SFX");
        player = GameObject.FindGameObjectWithTag("Player");
        objectCollider = gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f * Time.deltaTime);
        if (SceneManager.GetSceneByName("InGame").isLoaded)
            coinMultiplierPowerUp = player.GetComponent<Movement>().coinMultiplierPowerUp;
        coinMultiplierValue = PlayerPrefs.GetInt("CoinMultiplierEffLevel");
        if (IsOverlappingOtherCollider())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && coinMultiplierPowerUp == false)
        {
            coinValue = 1;
            player.GetComponent<Movement>().coinsCollected += coinValue;
            sfx.GetComponent<AudioSource>().PlayOneShot(coinPickUp);
            foreach (Renderer renderer in coinRenderers)
            {
                renderer.enabled = false;
            }
        }
        else if(other.CompareTag("Player") && coinMultiplierPowerUp == true)
        {
            coinValue = coinMultiplierValue + 2;
            player.GetComponent<Movement>().coinsCollected += coinValue;
            sfx.GetComponent<AudioSource>().PlayOneShot(coinPickUp);
            foreach (Renderer renderer in coinRenderers)
            {
                renderer.enabled = false;
            }
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
