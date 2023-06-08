using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest: MonoBehaviour
{
    public GameObject uiPanel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            uiPanel.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            uiPanel.SetActive(false);
        }
    }
}


