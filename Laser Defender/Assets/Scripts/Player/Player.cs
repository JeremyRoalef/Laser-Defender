using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Shooter shooter;

    Vector2 moveInput;
    [SerializeField] float fltMoveSpeed;



    [SerializeField] float fltPaddingLeft;
    [SerializeField] float fltPaddingRight;
    [SerializeField] float fltPaddingUp;
    [SerializeField] float fltPaddingDown;
    Vector2 minBoundary;
    Vector2 maxBoundary;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }


    void Update()
    {

        PlayerMovement();

    }

    void InitBounds()
    {
        //viewports represent the camera world space in the game.
        //ViewportToWorldPoint sets the x and y viewport space to world space. basically, relate viewport space is converted to absolute space
        Camera mainCamera = Camera.main;
        minBoundary = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBoundary = mainCamera.ViewportToWorldPoint (new Vector2 (1,1));
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.boolIsFiring = value.isPressed;
        }
    }

    private void PlayerMovement()
    {
        Vector2 delta = moveInput * fltMoveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2 ();

        newPosition.x = Mathf.Clamp (transform.position.x + delta.x, minBoundary.x + fltPaddingLeft, maxBoundary.x - fltPaddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBoundary.y + fltPaddingDown, maxBoundary.y - fltPaddingUp);

        transform.position = newPosition;
    }

}
