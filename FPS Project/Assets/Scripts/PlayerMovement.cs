using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction wasd;
    public InputAction mouse;
    
    public CharacterController controller;
    
    public float gravity = -9.81f;
    Vector3 verticalVelocity;
    public LayerMask groundMask;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;


    private void OnEnable() 
    {
        wasd.Enable();
    }

    private void OnDisable() 
    {
        wasd.Disable();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && verticalVelocity.y < 0){
            verticalVelocity.y = 0f;
        }
        
        //Gravity
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

        //Ground Movement
        Vector2 inputVector = wasd.ReadValue<Vector2>();
        Vector3 finalVector = new Vector3();

        finalVector.x = inputVector.x;
        finalVector.z = inputVector.y;

        controller.Move(finalVector * Time.deltaTime * 10f);
    }
}
