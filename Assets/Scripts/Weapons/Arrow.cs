using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Rigidbody2D rb;

    [Header("Arrow Settings")]
    [SerializeField] private float arrowSpeed;
    [SerializeField] private int arrowDestroyTime = 5;

    [Header("Death VFX")]
    [SerializeField] private GameObject deathVFX;


    public Vector2 ArrowDirection { get; set; }
    public float ArrowAngle { get; set; }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetArrowRotation();
        Destroy(this.gameObject, arrowDestroyTime);
    }


    private void FixedUpdate()
    {
        ArrowMovement();
    }

    private void ArrowMovement()
    {
        rb.MovePosition(rb.position + ArrowDirection * (arrowSpeed * Time.fixedDeltaTime));
    }

    private void SetArrowRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, ArrowAngle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            Destroy(this.gameObject);
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
    }

}
