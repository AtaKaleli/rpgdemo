using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    private PlayerControls playerControls;

    private Rigidbody2D rb;
    private Animator anim;



    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;
    private Vector2 movement;
    public bool IsFacingRight { get; private set; }
    public bool CanMove { get; set; }

    [Header("Dash Ability Information")]
    [SerializeField] private float dashSpeedMultiplier;
    [SerializeField] private float dashTimer;
    [SerializeField] private float dashCooldown;
    private float defaultMoveSpeed;
    private bool canDash = true;
    private TrailRenderer trailRenderer;



    private void Awake()
    {
        if (instance != null && this.gameObject != null)
            Destroy(this.gameObject);
        else
            instance = this;


        playerControls = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();



        DontDestroyOnLoad(gameObject);

    }



    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        IsFacingRight = true;
        CanMove = true;
        defaultMoveSpeed = moveSpeed;

        playerControls.Combat.Dash.started += _ => DashAbility();
    }


    private void Update()
    {
        

        HandleMovementInput();
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

    private void HandleMovementInput()
    {
        if (CanMove)
            movement = playerControls.Movement.Move.ReadValue<Vector2>();
        else
            movement = new Vector2(0, 0);
    }

    private void Move()
    {
        if(CanMove)
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void FlipController()
    {


        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        float distance = mouseWorldPos.x - transform.position.x;

        if ((distance < 0 && IsFacingRight) || (distance > 0 && !IsFacingRight))
            Flip();
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void DashAbility()
    {
        if (canDash)
            StartCoroutine(DashTimerCouroutine());
    }

    private IEnumerator DashTimerCouroutine()
    {
        canDash = false;
        trailRenderer.emitting = true;
        moveSpeed *= dashSpeedMultiplier;
        yield return new WaitForSeconds(dashTimer);
        trailRenderer.emitting = false;
        moveSpeed = defaultMoveSpeed;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
