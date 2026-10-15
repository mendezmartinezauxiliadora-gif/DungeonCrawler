using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 720f; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] float Gravity = -20;
    [SerializeField] float jumpHeight = 2f;
    private  float verticalVelocity;
    private CharacterController chController;

    void Start()
    {
        chController = GetComponent<CharacterController>();
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
        Vector3 camRight = cameraTransform != null ? cameraTransform.right : Vector3.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camRight * Horizontal + camForward * Vertical;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        if (moveDirection.sqrMagnitude > 0.0001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        chController.Move(moveDirection * moveSpeed * Time.deltaTime);

        
        if (chController.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        if (chController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }

        verticalVelocity += Gravity * Time.deltaTime;

        
        Vector3 finalMove = moveDirection * moveSpeed;
        finalMove.y = verticalVelocity;

        chController.Move(finalMove * Time.deltaTime);
    }
}
