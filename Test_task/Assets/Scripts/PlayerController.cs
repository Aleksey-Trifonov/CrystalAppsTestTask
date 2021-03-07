using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontalInput, 0f, verticalInput);

        if (movementVector.magnitude != 0f)
        {
            movementVector.Normalize();
            movementVector *= speed * Time.deltaTime;
            transform.Translate(movementVector, Space.Self);
        }

        float velocityZ = Vector3.Dot(movementVector.normalized, transform.forward);
        float velocityX = Vector3.Dot(movementVector.normalized, transform.right);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    private void LateUpdate()
    {
        //rotate towards camera
    }
}
