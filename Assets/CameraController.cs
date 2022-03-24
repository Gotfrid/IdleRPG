using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform CameraTransform;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private int CameraZOffset = -3;
    
    private Vector3 CameraStartOffset = new Vector3(5, 7, 0);

    // Start is called before the first frame update
    void Start()
    {
        CameraTransform.position = PlayerTransform.position + CameraStartOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraTransform.position = new Vector3(
            CameraTransform.position.x,
            CameraTransform.position.y,
            PlayerTransform.position.z + CameraZOffset
        );
    }
}
