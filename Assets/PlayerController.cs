using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Constant speed of the player's movement
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float SideSpeed = 20000;
    [SerializeField] private Rigidbody rb;

    private float HorizontalMovement;

    private void Start() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        // Move forward constantly
        rb.velocity = new Vector3(0, 0, MoveSpeed);

        // Move sideways
        HorizontalMovement = Input.GetAxis("Horizontal");
        rb.AddForce(SideSpeed * HorizontalMovement * Time.fixedDeltaTime, 0, 0);
    }

}
