using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private GameObject player;
    private GameObject score;
    private GameObject tileStorage;
    private GameObject tileList;
    public Transform playerPos;
    public float spawnLoc;
    public float tileLength;
    public float maxTiles;
    public int duplicateCount;
    void Start()
    {
        tileStorage = GameObject.Find("TileStorage");
        tileList = GameObject.Find("TileList");
        for (int i = 0; i < tileList.transform.childCount;)
        {
            GameObject childObject = tileList.transform.GetChild(i).gameObject;
            GameObject emptyObject = new GameObject(childObject.name);
            childObject.transform.SetParent(emptyObject.transform);
            emptyObject.transform.SetParent(tileStorage.transform);
            childObject.SetActive(false);
            for (int t = 0; t < duplicateCount; t++)
            {
                GameObject duplicatedObject = Instantiate(childObject);
                duplicatedObject.name = childObject.name;
                duplicatedObject.transform.SetParent(emptyObject.transform);
            }
        }

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < maxTiles; i++)
        {
            SpawnTile();
        }
    }
    void Update()
    {
        if (playerPos.position.z > spawnLoc - (maxTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    void SpawnTile()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.Find("Score");

        if (score.GetComponent<ScoreScript>().difficulty1 == false)
        {
            int randomNum = Random.Range(0, tileStorage.transform.childCount);
            GameObject tile;
            tile = tileStorage.transform.GetChild(randomNum).GetChild(0).gameObject;
            tile.transform.position = Vector3.forward * spawnLoc;
            tile.SetActive(true);
            tile.transform.SetParent(transform);
            spawnLoc += tileLength;
        }
    }
    void DeleteTile()
    {
        GameObject spawnedTile = GameObject.Find("TileSpawner");
        GameObject child = spawnedTile.transform.GetChild(0).gameObject;

        if (spawnedTile.transform.childCount == maxTiles + 2)
        {
            GameObject returnObject = GameObject.Find(child.name);
            if(returnObject.name == "SpawnTile")
            {
                Destroy(returnObject);
            }
            child.transform.SetParent(returnObject.transform);
            child.transform.position = tileStorage.transform.position;
            child.GetComponentInChildren<CoinSpawner>().ResetSpawener(); //Resets Coin Sapwner
            child.SetActive(false);
        }
    }
}
