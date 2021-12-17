using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public bool AppleControlsDebug;
    public float speed = 5;
    Vector2 velocity;

    private void Update()
    {
        if (AppleControlsDebug)
        {
            if (Input.GetButton("Walk"))
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
            
        else
        {
            velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(velocity.x, 0, velocity.y);
        }
        
            
    }
}
