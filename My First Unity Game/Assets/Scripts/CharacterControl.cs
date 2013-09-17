using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public Control MoveForward;
    public Control MoveBackward;
    public Control TurnLeft;
    public Control TurnRight;
    public Control Jump;

    public float moveSpeed = 5f;
    public float rotSpeed = 100f;
    public float jumpHeight = 8f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;

    /*    private float trueSpeed
        {
            get { return (moveSpeed * Time.deltaTime); }
        }

        private float trueRotSpeed
        {
            get { return (rotSpeed * Time.deltaTime); }
        }
    */

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if(Input.GetButtonDown("Jump"))
                moveDirection.y = jumpHeight;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Horizontal"));
    }

}
