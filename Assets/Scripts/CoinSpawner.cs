using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject invincibilityPowerUp;
    public GameObject coinMultiplierPowerUp;
    public GameObject coinBundlePowerUp;
    public int numOfCoins = 10;
    public Collider targetCollider;
    public GameObject coinContainer;
    public int zOffSet;
    public bool coinCapped = false;
    public bool powerUpSpawned = false;
    public bool attemptedPowerUpSpawn = false;


    void Start()
    {

    }
    void Update()
    {
        if(coinCapped == false)
        {
            SpawnObjects();
        }
        if(attemptedPowerUpSpawn == false)
        {
            PowerUpSpawner();
        }        
    }
    private void SpawnObjects()
    {
        if (gameObject.transform.childCount < 1)
        {

            Vector3 randomPos = GetRandomPosInsideCollider();
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.SetParent(coinContainer.transform);
            coin.transform.position = randomPos;

        }
        else if (gameObject.transform.childCount < numOfCoins)
        {

            for (int i = 1; i < numOfCoins; i++)
            {
                int Z = (int)gameObject.transform.GetChild(0).position.z;
                int X = (int)gameObject.transform.GetChild(0).position.x;
                int Y = (int)gameObject.transform.GetChild(0).position.y;
                int childCount = gameObject.transform.childCount;
                GameObject coin = Instantiate(coinPrefab);
                coin.transform.SetParent(coinContainer.transform);
                coin.transform.position = new Vector3(X, Y, Z + (zOffSet * childCount));

            }
        }
        else
        {
            coinCapped = true;
        }

    }

    private Vector3 GetRandomPosInsideCollider()
    {
        Bounds bounds = targetCollider.bounds;
        float randomX = Random.Range((int)bounds.min.x + 3, (int)bounds.max.x - 3);
        float Y = (int)bounds.center.y;
        float randomZ = Random.Range((int)bounds.min.z + 5, (int)bounds.center.z);
        return new Vector3(randomX, Y, randomZ);
    }
    public void PowerUpSpawner()
    {
        int random = Random.Range(0, 10);
        if (random == 1)
        {
            Vector3 randomPos = GetRandomPosInsideCollider();
            GameObject powerUp = Instantiate(invincibilityPowerUp);
            powerUp.transform.SetParent(coinContainer.transform);
            powerUp.transform.position = randomPos;
            powerUpSpawned = true;
            attemptedPowerUpSpawn = true;
        }
        else if(random == 2)
        {
            Vector3 randomPos = GetRandomPosInsideCollider();
            GameObject powerUp = Instantiate(coinMultiplierPowerUp);
            powerUp.transform.SetParent(coinContainer.transform);
            powerUp.transform.position = randomPos;
            powerUpSpawned = true;
            attemptedPowerUpSpawn = true;
        }
        else if (random == 3)
        {
            Vector3 randomPos = GetRandomPosInsideCollider();
            GameObject powerUp = Instantiate(coinBundlePowerUp);
            powerUp.transform.SetParent(coinContainer.transform);
            powerUp.transform.position = randomPos;
            powerUpSpawned = true;
            attemptedPowerUpSpawn = true;
        }
        else
        {
            attemptedPowerUpSpawn = true;
        }
    }
    public void ResetSpawener() //REMINDER : called from 'TileSpawner'
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            Destroy(childObject);
        }
        coinCapped = false;
        powerUpSpawned = false;
        attemptedPowerUpSpawn = false;
    }

}