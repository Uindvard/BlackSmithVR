using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenProJob: MonoBehaviour
{
    public float heatingDelay = 8f;
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
                isHeating = false; // Остановка нагревания после создания нагретого слитка
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Metal") && !isHeating)
        {
            isHeating = true;
            currentHeatingTime = 0f;
            currentMetalObject = other.gameObject; // Сохраняем ссылку на текущий обычный слиток
        }
    }

    private void HeatMetal()
    {
        if (currentMetalObject != null && heatedMetalPrefab != null)
        {
            GameObject heatedMetal = Instantiate(heatedMetalPrefab, currentMetalObject.transform.position, currentMetalObject.transform.rotation);
            Destroy(currentMetalObject); // Удаление обычного слитка
        }
    }
}