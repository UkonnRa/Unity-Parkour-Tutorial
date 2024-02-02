using UnityEngine;
using UnityEngine.InputSystem;

namespace PT
{
  public class MovementController : MonoBehaviour
  {
    public float walkSpeed = 5;
    public Transform cameraTransform;

    private Vector2 _moveAmount;

    private void Update()
    {
      var cameraForward = cameraTransform.forward;
      var cameraRight = cameraTransform.right;
      var forward = new Vector3(cameraForward.x, 0, cameraForward.z);
      var right = new Vector3(cameraRight.x, 0, cameraRight.z);
      transform.position += Time.deltaTime * walkSpeed *
                            (forward.normalized * _moveAmount.y + right.normalized * _moveAmount.x);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
      _moveAmount = context.ReadValue<Vector2>();
    }
  }
}
