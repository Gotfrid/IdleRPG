using UnityEngine;

public class PlayerController : MonoBehaviour
{

  // Constant speed of the player's movement
  [SerializeField] private float MoveSpeed;
  [SerializeField] private float SideSpeed = 20000;
  [SerializeField] private Rigidbody rb;

  private float HorizontalMovement;
  private float LeftBoundary = -4f;
  private float RightBoundary = 4f;

  private void Start()
  {
    rb.constraints = RigidbodyConstraints.FreezeRotation;
  }

  private void FixedUpdate()
  {
    // Move forward constantly
    MoveSpeed = DataContainer.Speed;
    rb.velocity = new Vector3(0, 0, MoveSpeed);

    // Move sideways
    HorizontalMovement = Input.GetAxis("Horizontal");
    rb.AddForce(SideSpeed * HorizontalMovement * Time.fixedDeltaTime, 0, 0);

    // Set movement boundaries
    // TODO: is there a way to do it better?
    if (rb.position.x <= LeftBoundary)
    {
      rb.position = new Vector3(LeftBoundary, rb.position.y, rb.position.z);
    }
    if (rb.position.x >= RightBoundary)
    {
      rb.position = new Vector3(RightBoundary, rb.position.y, rb.position.z);
    }
  }
}
