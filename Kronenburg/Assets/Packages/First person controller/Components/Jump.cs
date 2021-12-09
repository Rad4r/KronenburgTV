using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;

    public float maxGroundDistance = .3f;
    private bool isGrounded;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && CheckIsGrounded())
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
    }

    bool CheckIsGrounded()
    {
        Vector3 groundCheckPosition = transform.position + Vector3.up * .01f;
        return Physics.Raycast(groundCheckPosition, Vector3.down, maxGroundDistance);
    }
}
