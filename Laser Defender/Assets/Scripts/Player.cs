using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float fltMoveSpeed;

    void Start()
    {
        
    }


    void Update()
    {

        PlayerMovement();

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        Debug.Log(moveInput);
    }

    private void PlayerMovement()
    {
        //change in future to make player move up and down with delta value of +1 or -1. else moving at an angle is slower

        Vector3 delta = moveInput;
        transform.position += delta * fltMoveSpeed * Time.deltaTime;
    }

}
