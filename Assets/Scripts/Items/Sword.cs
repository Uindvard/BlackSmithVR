using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Ссылка на префаб меча")]
    public GameObject swordPrefab; 

    [Header("Пороговое значение")]
    public int hitThreshold = 4; 

    private int hitCount = 0; 
    private bool hasCreatedSword = false; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer") && !hasCreatedSword)
        {
            hitCount++; 


            if (hitCount >= hitThreshold)
            {
                TransformIntoSword();
            }
        }
    }

    private void TransformIntoSword()
    {
        Destroy(gameObject);
        Instantiate(swordPrefab, transform.position, transform.rotation);
        hasCreatedSword = true; 
    }
}
