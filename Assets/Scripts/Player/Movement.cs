using UnityEngine;
using UnityEngine.XR;

public class VRMovement : MonoBehaviour
{
    public XRNode inputSource; 

    private Vector2 inputAxis; 

    public float movementSpeed = 3f;
    public float rotationSpeed = 90f; 

    private CharacterController characterController; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        Vector3 movement = transform.TransformDirection(direction) * movementSpeed * Time.deltaTime;

        characterController.Move(movement);

       
        transform.Rotate(Vector3.up, inputAxis.x * rotationSpeed * Time.deltaTime);
    }
}