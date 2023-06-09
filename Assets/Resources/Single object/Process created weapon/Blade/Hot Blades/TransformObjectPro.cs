using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float strikeForce = 10f; // Сила удара молота
    public LayerMask forgeLayer; // Слой коллайдера наковальни

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверяем нажатие левой кнопки мыши
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, forgeLayer)) // Проверяем, попал ли молот в коллайдер наковальни
            {
                Forge forge = hit.collider.GetComponent<Forge>(); // Получаем компонент Forge с коллайдера наковальни
                if (forge != null)
                {
                    forge.ApplyStrike(strikeForce); // Вызываем функцию ApplyStrike() у компонента Forge и передаем силу удара
                }
            }
        }
    }
}