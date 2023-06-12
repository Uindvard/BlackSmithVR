using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum ObjectState
{
    Unfinished,
    Finished
}

public class Anvil : MonoBehaviour
{
    private int hammerHits = 0; // ���������� ������ ������� �� �������
    private GameObject currentObject; // ������� ������ �� ����������
    public GameObject finishedObjectPrefab; // ������ �������� �������

    public void HitWithHammer()
    {
        if (currentObject != null)
        {
            hammerHits++;

            if (hammerHits >= 6)
            {
                ForgeObject();
            }
        }
    }

    private void ForgeObject()
    {
        if (currentObject != null && hammerHits >= 6)
        {
            // ������� ������� ������
            GameObject finishedObject = Instantiate(finishedObjectPrefab, transform.position, transform.rotation);

            // ���������� ��������� ������
            Destroy(currentObject);

            // �������� ������� ������ �� ����������
            finishedObject.transform.SetParent(transform);

            // ������������� ���������� ������� � �������� �������� ������� �� ����������
            finishedObject.transform.localPosition = Vector3.zero;
            finishedObject.transform.localRotation = Quaternion.identity;

            // ��������� ������� ������ �� ����������
            currentObject = finishedObject;

            // ��������� ���������� ������
            hammerHits = 0;
        }
    }

    private void ResetAnvil()
    {
        currentObject = null;
        hammerHits = 0;
    }

    // ����� ��� ��������� �������� ������� �� ����������
    public void SetCurrentObject(GameObject newObject)
    {
        currentObject = newObject;
        hammerHits = 0;
    }
}
