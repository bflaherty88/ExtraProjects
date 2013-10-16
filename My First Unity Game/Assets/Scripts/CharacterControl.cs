using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterControl))]
public class CharacterControl : MonoBehaviour
{
    CharacterController controller;

    public float moveSpeed = 5f;
    public float rotSpeed = 100f;
    public float jumpHeight = 8f;
    public float jumpBoost = 1.5f;
    public float gravity = 20f;
    public int health = 100;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpHeight;
                moveDirection.z *= jumpBoost;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag.Equals("Bullet"))
            health -= 10;
    }

}
