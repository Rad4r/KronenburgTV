using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;

    private void Update()
    {
        if (Input.GetButton("Walk"))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
