using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Constant speed of the player's movement
    [SerializeField] private float MoveSpeed = 1000f;
    [SerializeField] private float SideSpeed = 10f;
    [SerializeField] private Rigidbody rb;

    private float HorizontalMovement;

    private void Start() {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        // Move forward constantly
        rb.AddForce(0, 0, MoveSpeed * Time.fixedDeltaTime);

        // Move sideways
        HorizontalMovement = Input.GetAxis("Horizontal");
        if (HorizontalMovement != 0)
        {
            Debug.Log(HorizontalMovement);
        }
        rb.AddForce(SideSpeed * HorizontalMovement * Time.fixedDeltaTime, 0, 0);
    }

}
