using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private Vector2 movePosition;

    private Knockback knockback;

    private bool isFacingRight = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();
    }

    private void FixedUpdate()
    {
        Move();
        FlipController();
    }

    private void Move()
    {
        if (!knockback.IsKnocked)
            rb.MovePosition(rb.position + movePosition * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMovePosition(Vector2 nextPosition)
    {
        movePosition = nextPosition;
    }

    private void FlipController()
    {
        if ((movePosition.x < 0 && isFacingRight) || (movePosition.x > 0 && !isFacingRight))
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
}
