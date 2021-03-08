using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; 
    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private float deadZoneDegrees = 15f;

    private Animator animator = null;
    private Transform cameraTransform = null;
    private bool isInputEnabled = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (isInputEnabled)
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

            animator.SetFloat("VelocityZ", verticalInput, 0.1f, Time.deltaTime);
            animator.SetFloat("VelocityX", horizontalInput, 0.1f, Time.deltaTime);

            var cameraDirection = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z);
            var playerDirection = new Vector3(transform.forward.x, 0f, transform.forward.z);

            if (Vector3.Angle(cameraDirection, playerDirection) > deadZoneDegrees)
            {
                var targetRotation = Quaternion.LookRotation(cameraDirection, transform.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

    public void StartDialogue()
    {
        isInputEnabled = false;
        animator.SetFloat("VelocityZ", 0f, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", 0f, 0.1f, Time.deltaTime);
        animator.SetTrigger("Begin_dialogue");
    }
}
