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
    private int hammerHits = 0; // количество ударов молотом по объекту
    private GameObject currentObject; // текущий объект на наковальне
    public GameObject finishedObjectPrefab; // префаб готового объекта

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
            // Создаем готовый объект
            GameObject finishedObject = Instantiate(finishedObjectPrefab, transform.position, transform.rotation);

            // Уничтожаем неготовый объект
            Destroy(currentObject);

            // Помещаем готовый объект на наковальню
            finishedObject.transform.SetParent(transform);

            // Устанавливаем правильные позицию и вращение готового объекта на наковальне
            finishedObject.transform.localPosition = Vector3.zero;
            finishedObject.transform.localRotation = Quaternion.identity;

            // Обновляем текущий объект на наковальне
            currentObject = finishedObject;

            // Обновляем количество ударов
            hammerHits = 0;
        }
    }

    private void ResetAnvil()
    {
        currentObject = null;
        hammerHits = 0;
    }

    // Метод для установки текущего объекта на наковальню
    public void SetCurrentObject(GameObject newObject)
    {
        currentObject = newObject;
        hammerHits = 0;
    }
}
