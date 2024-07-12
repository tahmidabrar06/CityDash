using System.Collections;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Material[] materials;
    public float minDuration = 2f;
    public float maxDuration = 5f;
    public int targetIndex = 1;

    private Renderer materialRenderer;
    private int currentIndex = 0;
    private float currentDuration = 0f;

    private void Start()
    {
        materialRenderer = GetComponent<Renderer>();
        if (materials == null || materials.Length == 0)
        {
            enabled = false;
            return;
        }
        if (targetIndex < 0 || targetIndex >= materialRenderer.sharedMaterials.Length)
        {
            enabled = false;
            return;
        }
        SetRandomDuration();
        InvokeRepeating("CycleMaterial", currentDuration, currentDuration);
    }

    private void SetRandomDuration()
    {
        currentDuration = Random.Range(minDuration, maxDuration);
    }

    private void CycleMaterial()
    {
        currentIndex = (currentIndex + 1) % materials.Length;

        Material[] newMaterials = materialRenderer.sharedMaterials;

        newMaterials[targetIndex] = materials[currentIndex];

        materialRenderer.sharedMaterials = newMaterials;

        SetRandomDuration();
    }
}
