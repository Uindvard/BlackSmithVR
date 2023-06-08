using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformer: MonoBehaviour
{
    public GameObject swordPrefab; // ������ �� ������ ����
    public int hitThreshold = 4; // ��������� �������� ��� ���������� ������

    private int hitCount = 0; // ������� ������

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ���� ������������ ��������� � �������
        if (collision.gameObject.CompareTag("Hammer"))
        {
            hitCount++; // ����������� ������� ������

            // ���������, ���������� �� ��������� �������� ������
            if (hitCount >= hitThreshold)
            {
                TransformIntoSword(); // ����������� ������ � ���
            }
        }
    }

    private void TransformIntoSword()
    {
        // ���������� ������� ������
        Destroy(gameObject);

        // ������� ��������� ���� �� ������� � ��������� ��� �� ��� �� �����
        Instantiate(swordPrefab, transform.position, transform.rotation);
    }
}
