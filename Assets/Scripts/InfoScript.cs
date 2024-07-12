using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public GameObject infoWindow;
    // Start is called before the first frame update
    void Start()
    {
        infoWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHover()
    {
        infoWindow.SetActive(true);
    }
    public void OnHoverRemove()
    {
        infoWindow.SetActive(false);
    }
}
