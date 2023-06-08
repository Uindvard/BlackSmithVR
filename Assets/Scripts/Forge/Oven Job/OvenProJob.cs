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
    public Transform temperatureIndicator; // ������ �� ������, �������������� ��������� �����������

    private float currentTemperature = 0f;
    private bool isHeated = false;

    private void Update()
    {
        // ����������� ����������� � �������� ���������
        currentTemperature += temperatureIncreaseRate * Time.deltaTime;
        currentTemperature = Mathf.Clamp(currentTemperature, minTemperature, maxTemperature);

        // ��������� ��������� ����������� � UI
        UpdateTemperatureIndicator();

        // ���������, �������� �� ����������� ���������� ��������
        if (currentTemperature >= 1500f && !isHeated)
        {
            Debug.Log("���� ��� 1500 �������");
            HeatMetal();
        }
    }

    private void UpdateTemperatureIndicator()
    {
        // ��������� �������� ���������� ����������� � UI
        if (temperatureIndicator != null)
        {
            // ������: �����������, ��� � ���������� ���� ��������� Image � Text ��� ����������� �������� �����������
            // ��������� �������� Image ��� Text � ������������ � ������� ������������
        }
    }

    private void HeatMetal()
    {
        // �������� ������ �������� ������� �� �������� ������
        if (normalMetalPrefab != null && heatedMetalPrefab != null)
        {
            Instantiate(heatedMetalPrefab, transform.position, transform.rotation);
            Destroy(normalMetalPrefab.gameObject);
            isHeated = true;
        }
    }
}
