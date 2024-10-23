using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;





    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        
        PlayerInput();
        AnimationController();
    }

    private void FixedUpdate()
    {
        FlipController();
        Move();
    }

    private void AnimationController()
    {
        anim.SetFloat("xVelocity", movement.x);
        anim.SetFloat("yVelocity", movement.y);
    }



    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

    }

    private void FlipController()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        
        FlipChecks(mousePos, playerScreenPoint);

    }

    private void FlipChecks(Vector3 mousePos, Vector3 playerScreenPoint)
    {
        if (mousePos.x < playerScreenPoint.x)
            sr.flipX = true;
        else
            sr.flipX = false;
    }
}
