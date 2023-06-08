using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformer: MonoBehaviour
{
    public GameObject swordPrefab; // Ссылка на префаб меча
    public int hitThreshold = 4; // Пороговое значение для количества ударов

    private int hitCount = 0; // Счетчик ударов

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, если столкновение произошло с молотом
        if (collision.gameObject.CompareTag("Hammer"))
        {
            hitCount++; // Увеличиваем счетчик ударов

            // Проверяем, достигнуто ли пороговое значение ударов
            if (hitCount >= hitThreshold)
            {
                TransformIntoSword(); // Преобразуем объект в меч
            }
        }
    }

    private void TransformIntoSword()
    {
        // Уничтожаем текущий объект
        Destroy(gameObject);

        // Создаем экземпляр меча из префаба и размещаем его на том же месте
        Instantiate(swordPrefab, transform.position, transform.rotation);
    }
}
