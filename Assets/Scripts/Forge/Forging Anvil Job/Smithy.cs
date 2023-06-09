using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge: MonoBehaviour
{
    public GameObject ingotPrefab; 
    public GameObject bladePrefab;
    public GameObject brokenPrefab;

    private int strikeCount; 

    public void ApplyStrike(float strikeForce)
    {
        if (strikeCount < 6)
        {
            strikeCount++;

            if (strikeCount >= 6 && strikeCount <= 8)
            {
                Destroy(ingotPrefab); 
                GameObject blade = Instantiate(bladePrefab, transform.position, transform.rotation); 
                blade.transform.SetParent(transform); 
            }
            if (strikeCount > 8)
            {
                Destroy(bladePrefab);
                GameObject Brokenlade = Instantiate(brokenPrefab, transform.position, transform.rotation);
                Brokenlade.transform.SetParent(transform);
            }
        }
    }
}
