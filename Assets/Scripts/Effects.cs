using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public float activeTime; // linked to invincibilityDurqa in PowerUpManager
    private GameObject player;
    public bool invincibilityEffect = false;

    [Header("MeshRelated")]
    public float meshDestroyDelay = 3f;
    public Transform positionToSpawn;

    [Header("ShaderRelated")]
    public Material mat;

    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (invincibilityEffect == false && player.GetComponent<Movement>().invincibilityPowerUp == true)
        {
            activeTime = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>().invincibilityDura;
            StartCoroutine(ActivateTrail(activeTime));

            invincibilityEffect = true;
        }
        else if (player.GetComponent<Movement>().invincibilityPowerUp == false)
        {
            invincibilityEffect = false;
        }
    }

    IEnumerator ActivateTrail(float timeActive)
    {
        timer = 0f;

        while (timer < timeActive)
        {
            timer += Time.deltaTime;

            if (skinnedMeshRenderers == null)
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            if (Time.timeScale != 0)
            {
                for (int i = 0; i < skinnedMeshRenderers.Length; i++)
                {
                    GameObject gObj = new GameObject();
                    Vector3 newPosition = positionToSpawn.position + new Vector3(0f, 1.8f, 0f);
                    gObj.transform.SetPositionAndRotation(newPosition, positionToSpawn.rotation);

                    MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
                    MeshFilter mf = gObj.AddComponent<MeshFilter>();

                    Mesh mesh = new Mesh();
                    skinnedMeshRenderers[i].BakeMesh(mesh);

                    mf.mesh = mesh;
                    mr.material = mat;

                    Destroy(gObj, meshDestroyDelay);
                    Destroy(mesh, meshDestroyDelay);
                }
            }

            yield return null;
        }
    }
}