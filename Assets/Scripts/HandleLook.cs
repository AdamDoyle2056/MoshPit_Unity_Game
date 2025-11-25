// HandleLook.cs
using UnityEngine;

public class HandleLook : MonoBehaviour
{
    public Transform player;
    public Transform head;
    public float lookSpeed = 2f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        player.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);
        head.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}