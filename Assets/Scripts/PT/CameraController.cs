using UnityEngine;
using UnityEngine.InputSystem;

namespace PT
{
  public class CameraController : MonoBehaviour
  {
    public Transform target;
    public float cameraArmLength = 5.0f;

    public float horizontalSpeed = 1;
    public Vector2 horizontalAngleRange = new(-60, 60);
    public Vector2 verticalAngleRange = new(-15, 30);
    public float rotationCenterOffset = 1.0f;
    private float _horizontalAngle;

    private Vector2 _lookDelta;
    private float _verticalAngle;

    private void Update()
    {
      var speedRatio = (verticalAngleRange.y - verticalAngleRange.x) /
                       (horizontalAngleRange.y - horizontalAngleRange.x);
      _verticalAngle = Mathf.Clamp(_verticalAngle + horizontalSpeed * speedRatio * _lookDelta.y,
        verticalAngleRange.x, verticalAngleRange.y);
      _horizontalAngle = Mathf.Clamp(_horizontalAngle + horizontalSpeed * _lookDelta.x,
        horizontalAngleRange.x, horizontalAngleRange.y);

      var targetRotation = Quaternion.Euler(_verticalAngle, _horizontalAngle, 0);
      var rotationCenter = target.position + rotationCenterOffset * target.up;
      transform.position = rotationCenter - targetRotation * new Vector3(0, 0, cameraArmLength);
      transform.rotation = targetRotation;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
      _lookDelta = context.ReadValue<Vector2>();
    }
  }
}
