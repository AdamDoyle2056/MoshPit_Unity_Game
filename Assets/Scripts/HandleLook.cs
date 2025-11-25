using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLook : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform player;
    void Start()
    {
        // Locks mouse cursor in the center of the screen and hides it
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        player.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2);
    }

    void LateUpdate() 
    {
        // Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;   //  Edit the multiplier to adjust the rotate speed
        e.x = RestrictAngle(e.x, -85f, 85f);    //  This is clamped to 85 degrees
        head.eulerAngles = e;
    }

    //  Clamp the vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax) 
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}
