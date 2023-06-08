using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureIncreaseTrigger : MonoBehaviour
{
    public float temperatureThreshold = 1500f;
    public OvenProJob ovenProJob; // ссылка на скрипт FurnaceController

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект, активирующий триггер, игроком или другим объектом, отвечающим за увеличение температуры
        // Например, если это дрова или кузнечный механизм
        if (other.CompareTag("Fuel"))
        {
            ovenProJob = other.GetComponent<OvenProJob>();
            if (ovenProJob != null)
            {
                ovenProJob.temperatureIncreaseRate += temperatureThreshold;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Сбрасываем увеличение температуры, когда объект покидает триггер
        if (other.CompareTag("Fuel") && ovenProJob != null)
        {
            ovenProJob.temperatureIncreaseRate -= temperatureThreshold;
        }
    }
}
