using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlockLights : MonoBehaviour
{
    private bool action1;
    public Material red;
    public Material blue;
    public GameObject Object;
    void Start()
    {
        {
            // Call the Alternating function every second
            InvokeRepeating("Alternating", 0f, 1f);
        }

    }

    void Alternating()
    {
        if (action1)
        {
            Object.GetComponent<MeshRenderer>().material = blue;
        }
        else
        {
            Object.GetComponent<MeshRenderer>().material = red;
        }

        // Switch the flag
        action1 = !action1;
    }
}
