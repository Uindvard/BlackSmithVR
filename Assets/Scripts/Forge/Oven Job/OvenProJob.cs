using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenProJob: MonoBehaviour
{

    [Header("Пороговое значение")]
    public float heatingDelay = 8f;
    [Header("Ссылка на префаб раскаленного метала")]
    public GameObject heatedMetalPrefab;

    private bool isHeating = false;
    private float currentHeatingTime = 0f;
    private GameObject currentMetalObject;

    private void Update()
    {
        if (isHeating)
        {
            currentHeatingTime += Time.deltaTime;
            if (currentHeatingTime >= heatingDelay)
            {
                HeatMetal();
                isHeating = false; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Metal") && !isHeating)
        {
            isHeating = true;
            currentHeatingTime = 0f;
            currentMetalObject = other.gameObject; 
        }
    }

    private void HeatMetal()
    {
        if (currentMetalObject != null && heatedMetalPrefab != null)
        {
            GameObject heatedMetal = Instantiate(heatedMetalPrefab, currentMetalObject.transform.position, currentMetalObject.transform.rotation);
            Destroy(currentMetalObject);
        }
    }
}