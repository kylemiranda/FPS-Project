using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] float gravity = -30f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private float speed = 11f;
    [SerializeField] CharacterController controller;
    
    bool jump;
    bool isGrounded;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;

    
    private void Update ()
    {
        isGrounded = Physics.Raycast(controller.transform.position, Vector2.down, 1.1f, groundMask);
        if (isGrounded) {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

        // Jump: v = sqrt(-2 * jumpHeight * gravity)
        if (jump) {
            if (isGrounded) {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed ()
    {
        jump = true;
    }

}