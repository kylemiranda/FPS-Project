using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public InputAction WASD;
    public CharacterController Controller;

    private void OnEnable() 
    {
        WASD.Enable();
    }

    private void OnDisable() 
    {
        WASD.Disable();
    }

    void Start()
    {
        Controller = GetComponent<CharacterController>(); 
    }

    void Update()
    {
        Vector2 inputVector = WASD.ReadValue<Vector2>();
        Vector3 finalVector = new Vector3();

        finalVector.x = inputVector.x;
        finalVector.z = inputVector.y;

        Controller.Move(finalVector * Time.deltaTime * 3.14f);
    }
}
