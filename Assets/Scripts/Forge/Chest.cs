using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestInteraction : MonoBehaviour
{
    public GameObject uiPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller"))
        {
            uiPanel.SetActive(true);
        }
    }
}
