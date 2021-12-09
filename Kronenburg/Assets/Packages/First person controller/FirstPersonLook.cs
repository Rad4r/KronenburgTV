using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 1;


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
        Vector3 currentXRotation = character.rotation.eulerAngles + new Vector3(0, Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime, 0);
        Vector3 currentYRotation = transform.rotation.eulerAngles + new Vector3(-Input.GetAxis("Vertical") * sensitivity/2, Input.GetAxis("Horizontal") * sensitivity, 0) * Time.deltaTime;
        character.rotation = Quaternion.Euler(currentXRotation);
        transform.rotation = Quaternion.Euler(currentYRotation);
    }
}
