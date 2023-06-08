using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest: MonoBehaviour
{
    public GameObject chestUI; // ������ �� UI-������ � �������� ���������
    private bool isOpen = false; // ����, �����������, ������ �� ������

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� ������� ��������� � ����������� �����������
        if (other.CompareTag("Controller"))
        {
            // ���������, ���� ������ ������ ��������� �� �����������
            if (Input.GetButtonDown("XRI_LeftHand_Interaction_Activate_Value"))
            {
                // ����������� ��������� ������� (������/������)
                isOpen = !isOpen;

                // ���������� ��� �������� UI-������ � ����������� �� ��������� �������
                chestUI.SetActive(isOpen);
            }
        }
    }
}