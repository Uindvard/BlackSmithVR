using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest: MonoBehaviour
{
    public GameObject chestUI; // Ссылка на UI-панель с ячейками инвентаря
    private bool isOpen = false; // Флаг, указывающий, открыт ли сундук

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, если касание произошло с коллайдером контроллера
        if (other.CompareTag("Controller"))
        {
            // Проверяем, если нажата кнопка активации на контроллере
            if (Input.GetButtonDown("XRI_LeftHand_Interaction_Activate_Value"))
            {
                // Переключаем состояние сундука (открыт/закрыт)
                isOpen = !isOpen;

                // Показываем или скрываем UI-панель в зависимости от состояния сундука
                chestUI.SetActive(isOpen);
            }
        }
    }
}