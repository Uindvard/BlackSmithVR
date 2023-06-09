using UnityEngine;

public class Sword : MonoBehaviour
{
<<<<<<< Updated upstream
    [Header("Ссылка на префаб меча")]
    public GameObject swordPrefab; 

    [Header("Пороговое значение")]
    public int hitThreshold = 4; 

    private int hitCount = 0; 
=======
    public GameObject swordPrefab; 
    public int hitThreshold = 4; 

    private int hitCount = 0;
>>>>>>> Stashed changes
    private bool hasCreatedSword = false; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer") && !hasCreatedSword)
        {
            hitCount++; 
<<<<<<< Updated upstream

            
            if (hitCount >= hitThreshold)
            {
                TransformIntoSword();
=======
            
            if (hitCount >= hitThreshold)
            {
                TransformIntoSword(); 
>>>>>>> Stashed changes
            }
        }
    }

    private void TransformIntoSword()
    {
<<<<<<< Updated upstream
       
        Destroy(gameObject);

        
=======
        
        Destroy(gameObject);

       
>>>>>>> Stashed changes
        Instantiate(swordPrefab, transform.position, transform.rotation);

        hasCreatedSword = true; 
    }
}
