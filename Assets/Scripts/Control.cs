using UnityEngine;

public class Control : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float lookSpeed = 2f;

    private CharacterController characterController;
    private float yaw = 0f;
    private float pitch = 0f;
    private float fixedYPosition;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        fixedYPosition = transform.position.y;

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        move.y = 0;

        characterController.Move(move * moveSpeed * Time.deltaTime);

        Vector3 position = transform.position;
        position.y = fixedYPosition;
        transform.position = position;

        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
