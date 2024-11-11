using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;

    private Vector2 movePosition;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movePosition * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetMovePosition(Vector2 nextPosition)
    {
        movePosition = nextPosition;
    }
}
