using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("This is the object the camera will follow")]
    public Transform Target;

    [Tooltip("The higher the value the faster the camera will lock on the target")]
    public float SmoothSpeed = 5;

    [Tooltip("Sets camera rotation")]
    public Vector3 RotationVec = new Vector3(35f, 0, 0);
    [Tooltip("Vector3 that sets the distance (offset) between the target and the camera")]
    public Vector3 OffSetVec;

    private void Start()
    {
        transform.rotation = (Quaternion.Euler(RotationVec));
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = Target.position + OffSetVec;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, SmoothSpeed * Time.deltaTime);
        transform.position = new Vector3(0, smoothPos.y, smoothPos.z);
    }
}
