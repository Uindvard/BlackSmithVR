using UnityEngine;
using UnityEngine.XR;

public class VRMovement : MonoBehaviour
{
    public XRNode inputSource; // Выберите контроллер (левый или правый)

    private Vector2 inputAxis; // Движение по осям X и Z

    public float movementSpeed = 3f; // Скорость передвижения
    public float rotationSpeed = 90f; // Скорость поворота

    private CharacterController characterController; // Компонент CharacterController

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

        // Поворот
        transform.Rotate(Vector3.up, inputAxis.x * rotationSpeed * Time.deltaTime);
    }
}