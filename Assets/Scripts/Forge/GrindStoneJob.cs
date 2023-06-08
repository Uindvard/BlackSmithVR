using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindStoneJob: MonoBehaviour
{
    public float destructionDelay = 8f;

    
    public GameObject readyWeapon;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ready not grind"))
        {
            DestroyMetalAfterDelay(collision.gameObject);
        }
    }

    private void DestroyMetalAfterDelay(GameObject weapoonObject)
    {

        StartCoroutine(DestroyMetalCoroutine(weapoonObject));
    }

    private System.Collections.IEnumerator DestroyMetalCoroutine(GameObject weapoonObject)
    {
        yield return new WaitForSeconds(destructionDelay);


        Destroy(weapoonObject);

        Instantiate(readyWeapon, transform.position, transform.rotation);
    }
}
