using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private Vector2 movePosition;

    private Knockback knockback;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knockback = GetComponent<Knockback>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!knockback.IsKnocked)
            rb.MovePosition(rb.position + movePosition * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMovePosition(Vector2 nextPosition)
    {
        movePosition = nextPosition;
    }
}
