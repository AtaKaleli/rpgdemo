using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    private PlayerControls playerControls;

    private Rigidbody2D rb;
    private Animator anim;
    private Knockback knockback;


    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;
    private  Vector2 movement;
    public bool IsFacingRight { get; private set; } = true;
    public int FacingDirection { get; private set; } = 1;

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
        knockback = GetComponent<Knockback>();

        DontDestroyOnLoad(gameObject);

    }



    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        defaultMoveSpeed = moveSpeed;

        playerControls.Combat.Dash.started += _ => DashAbility();
    }


    private void Update()
    {
        AnimationController();

        if (knockback.IsKnocked)
        {
            StopPlayerMovement();
            return;
        }

        HandleMovementInput();
        FlipController();

        
        
    }

    private void StopPlayerMovement()
    {
        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        if (knockback.IsKnocked)
            return;


        Move();
    }


    private void AnimationController()
    {
        anim.SetFloat("xVelocity", movement.x);
        anim.SetFloat("yVelocity", movement.y);
    }

    private void HandleMovementInput()
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
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        float distance = mouseWorldPos.x - transform.position.x;

        if ((distance < 0 && IsFacingRight) || (distance > 0 && !IsFacingRight))
            Flip();
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        FacingDirection = FacingDirection * -1;
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
