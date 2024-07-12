using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMainMenu : MonoBehaviour
{
    public int driveSpeed;
    private int speed;
    private Vector3 driveDir;
    private Vector3 initialLocalPosition;
    private bool isReturning;

    public GameObject carObject;
    public Material[] materials;

    private float returnDelay;
    private float returnTimer;

    void Start()
    {
        StoreInitialLocalPosition();
        SetRandomReturnDelay();
        returnTimer = 0f;
        isReturning = false;
    }

    void Update()
    {
        if (!isReturning)
        {
            Drive();
            CheckReturn();
        }
        else
        {
            ReturnToInitialPosition();
        }
    }

    void Drive()
    {
        driveDir = new Vector3(1, 0, 0);
        speed = driveSpeed;
        Vector3 moveDistance = driveDir * speed * Time.deltaTime;
        transform.position += moveDistance;
    }

    void CheckReturn()
    {
        returnTimer += Time.deltaTime;
        if (returnTimer >= returnDelay)
        {
            isReturning = true;
        }
    }

    void ReturnToInitialPosition()
    {
        if (materials.Length > 0)
        {
            int randomIndex = Random.Range(0, materials.Length);
            Material randomMaterial = materials[randomIndex];
            Renderer renderer = carObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = randomMaterial;
            }
        }
        transform.localPosition = initialLocalPosition;
        isReturning = false;
        returnTimer = 0f;
        SetRandomReturnDelay();
    }

    private void StoreInitialLocalPosition()
    {
        initialLocalPosition = gameObject.transform.localPosition;
    }

    private void SetRandomReturnDelay()
    {
        returnDelay = Random.Range(3f, 8f);
    }
}