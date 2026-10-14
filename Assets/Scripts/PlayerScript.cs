using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float moveSpeed = 5f;
    private CharacterController chController;
    void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(Horizontal, 0, Vertical);

        Vector3 targetVelocity = input * 5f;

        input = Vector3.ClampMagnitude(input, 1);

        chController.Move(input * Time.deltaTime * 5f);
    }
}
