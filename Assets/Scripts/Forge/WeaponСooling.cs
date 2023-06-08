using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCooling: MonoBehaviour
{
    public float heatingDelay = 5f;
    public GameObject heatedWeaponPrefab;

    private bool isHeating = false;
    private float currentHeatingTime = 0f;
    private GameObject currentWeaponObject;

    private void Update()
    {
        if (isHeating)
        {
            currentHeatingTime += Time.deltaTime;
            if (currentHeatingTime >= heatingDelay)
            {
                HeatMetal();
                isHeating = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Non sharpened weapon") && !isHeating)
        {
            isHeating = true;
            currentHeatingTime = 0f;
            currentWeaponObject = other.gameObject; 
        }
    }

    private void HeatMetal()
    {
        if (currentWeaponObject != null && heatedWeaponPrefab != null)
        {
            GameObject heatedWeapon = Instantiate(heatedWeaponPrefab, currentWeaponObject.transform.position, currentWeaponObject.transform.rotation);
            Destroy(currentWeaponObject); 
        }
    }
}