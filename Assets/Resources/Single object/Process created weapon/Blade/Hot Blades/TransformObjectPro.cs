using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float strikeForce = 10f; // ���� ����� ������
    public LayerMask forgeLayer; // ���� ���������� ����������

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ��������� ������� ����� ������ ����
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, forgeLayer)) // ���������, ����� �� ����� � ��������� ����������
            {
                Forge forge = hit.collider.GetComponent<Forge>(); // �������� ��������� Forge � ���������� ����������
                if (forge != null)
                {
                    forge.ApplyStrike(strikeForce); // �������� ������� ApplyStrike() � ���������� Forge � �������� ���� �����
                }
            }
        }
    }
}