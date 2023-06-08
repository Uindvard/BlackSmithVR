using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenProJob: MonoBehaviour
{
    public float minTemperature = 0f;
    public float maxTemperature = 2000f;
    public float temperatureIncreaseRate = 10f;
    public Transform normalMetalPrefab;
    public Transform heatedMetalPrefab;
    public Transform temperatureIndicator; // ссылка на объект, представляющий индикатор температуры

    private float currentTemperature = 0f;
    private bool isHeated = false;

    private void Update()
    {
        // Увеличиваем температуру с заданной скоростью
        currentTemperature += temperatureIncreaseRate * Time.deltaTime;
        currentTemperature = Mathf.Clamp(currentTemperature, minTemperature, maxTemperature);

        // Обновляем индикатор температуры в UI
        UpdateTemperatureIndicator();

        // Проверяем, достигла ли температура порогового значения
        if (currentTemperature >= 1500f && !isHeated)
        {
            Debug.Log("Вася уже 1500 вырубай");
            HeatMetal();
        }
    }

    private void UpdateTemperatureIndicator()
    {
        // Обновляем значение индикатора температуры в UI
        if (temperatureIndicator != null)
        {
            // Пример: предположим, что у индикатора есть компонент Image и Text для отображения значения температуры
            // Обновляем значение Image или Text в соответствии с текущей температурой
        }
    }

    private void HeatMetal()
    {
        // Заменяем префаб обычного металла на нагретый металл
        if (normalMetalPrefab != null && heatedMetalPrefab != null)
        {
            Instantiate(heatedMetalPrefab, transform.position, transform.rotation);
            Destroy(normalMetalPrefab.gameObject);
            isHeated = true;
        }
    }
}
