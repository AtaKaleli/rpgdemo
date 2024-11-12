using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    private PlayerControls playerControls;
    
    private Rigidbody2D rb;
    private Animator anim;
    private Camera cam;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;
    private Vector2 movement;


    public bool IsFacingRight { get; private set; }




    private void Awake()
    {
        if (instance == null)
            instance = this;

        playerControls = new PlayerControls();
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        IsFacingRight = true;
    }


    private void Update()
    {

        HandlePlayerInput();
        AnimationController();
        FlipController();


    }

    private void FixedUpdate()
    {
        Move();
    }


    private void AnimationController()
    {
        anim.SetFloat("xVelocity", movement.x);
        anim.SetFloat("yVelocity", movement.y);
    }

    private void HandlePlayerInput()
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
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);

        float distance = mouseWorldPos.x - transform.position.x;

        if ((distance < 0 && IsFacingRight) || (distance > 0 && !IsFacingRight))
            Flip();
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(0, 180, 0);
    }

}
