using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureIncreaseTrigger : MonoBehaviour
{
    public float temperatureThreshold = 1500f;
    public OvenProJob ovenProJob; // ������ �� ������ FurnaceController

    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������, ������������ �������, ������� ��� ������ ��������, ���������� �� ���������� �����������
        // ��������, ���� ��� ����� ��� ��������� ��������
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
        // ���������� ���������� �����������, ����� ������ �������� �������
        if (other.CompareTag("Fuel") && ovenProJob != null)
        {
            ovenProJob.temperatureIncreaseRate -= temperatureThreshold;
        }
    }
}
