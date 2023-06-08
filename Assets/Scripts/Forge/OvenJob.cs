using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenJob: MonoBehaviour
{
    public float destructionDelay = 5f; 

    public GameObject materialWeapon;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Metal"))
        {
            DestroyMetalAfterDelay(collision.gameObject);
        }
    }

    private void DestroyMetalAfterDelay(GameObject metalObject)
    {
        
        StartCoroutine(DestroyMetalCoroutine(metalObject));
    }

    private System.Collections.IEnumerator DestroyMetalCoroutine(GameObject metalObject)
    {
        yield return new WaitForSeconds(destructionDelay);

        
        Destroy(metalObject);

        Instantiate(materialWeapon, transform.position, transform.rotation);
    }
}
