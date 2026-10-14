using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float horizontalMovement;
    [SerializeField] private float forwardMovement;
    [SerializeField] private float movementVelocity = 15; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(movementDirection, ForceMode.Acceleration);
        horizontalMovement = Input.GetAxis("Horizontal");
        forwardMovement = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalMovement, 0, forwardMovement);
      
    }

    void LateUpdate()
    {
        rb.AddForce(movementDirection, ForceMode.Acceleration);
    }
}
