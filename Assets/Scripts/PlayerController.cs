using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField] private float moveSpeed = 5.0f;
    private Vector2 movement;



    private PlayerControls playerControls;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }



    private void Update()
    {

        HandlePlayerInput();


    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandlePlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        
       
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}
