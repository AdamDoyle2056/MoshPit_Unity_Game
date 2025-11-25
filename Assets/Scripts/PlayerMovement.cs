// PlayerMovement.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private Vector3 input;

    void Start() => rb = GetComponent<Rigidbody>();

    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        Vector3 move = transform.TransformDirection(input) * speed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}