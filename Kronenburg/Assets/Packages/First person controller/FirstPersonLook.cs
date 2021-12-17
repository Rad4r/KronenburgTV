using System;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    private bool appleDebug;
    [SerializeField]
    Transform character;
    public float sensitivity = 1;
    
    //new
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float smoothing = 2;


    private void Awake()
    {
        appleDebug = FindObjectOfType<FirstPersonMovement>().AppleControlsDebug;

        if (appleDebug)
            sensitivity = 100;
    }

    void Reset()
    {
        character = transform.parent;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (appleDebug)
        {
            Vector3 currentXRotation = character.rotation.eulerAngles + new Vector3(0, Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime, 0);
            Vector3 currentYRotation = transform.rotation.eulerAngles + new Vector3(-Input.GetAxis("Vertical") * sensitivity/2, Input.GetAxis("Horizontal") * sensitivity, 0) * Time.deltaTime;
            character.rotation = Quaternion.Euler(currentXRotation);
            transform.rotation = Quaternion.Euler(currentYRotation);
        }
        else
        {
            // Get smooth mouse look.
            Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
            appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
            currentMouseLook += appliedMouseDelta;
            currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

            // Rotate camera and controller.
            transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);
        }
        
    }
}
