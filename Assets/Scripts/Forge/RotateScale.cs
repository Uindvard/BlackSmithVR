using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScale : MonoBehaviour
{
    public float rotationSpeed = 50f;


    void Update()
    {

        float currentRotation = transform.rotation.eulerAngles.x;


        float newRotation = currentRotation + rotationSpeed * Time.deltaTime;


        transform.rotation = Quaternion.Euler(newRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
