using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUpScript : MonoBehaviour
{
    private GameObject player;
    public Collider objectCollider;
    private float overlapRadius = 1.1f;
    private GameObject sfx;
    public AudioClip invincibilitySFX;

    void Start()
    {
        sfx = GameObject.Find("InGame-SFX");
        player = GameObject.FindGameObjectWithTag("Player");
        objectCollider = gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        if (IsOverlappingOtherCollider())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sfx.GetComponent<AudioSource>().PlayOneShot(invincibilitySFX);
            player.GetComponent<Movement>().invincibilityPowerUp = true;
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
