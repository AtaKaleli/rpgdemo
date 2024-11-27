using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Rigidbody2D rb;
    private WeaponSO weapon;

    [Header("Arrow Settings")]
    [SerializeField] private float arrowSpeed;
    private Transform startPos;
    

    [Header("Death VFX")]
    [SerializeField] private GameObject deathVFX;



    public Vector2 ArrowDirection { get; set; }
    public float ArrowAngle { get; set; }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = ActiveWeapon.instace.CurrentActiveWeapon.GetComponent<IWeapon>().GetWeapon();
    }

    private void Start()
    {
        SetArrowRotation();
        startPos = ActiveWeapon.instace.transform;
    }

    
    private void FixedUpdate()
    {
        DetectFireDistance();
        ArrowMovement();

        print(Vector2.Distance(transform.position, startPos.position));
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

    private void DetectFireDistance()
    {
        if(Vector2.Distance(transform.position,startPos.position) > weapon.weaponRange)
        {
            Destroy(this.gameObject);
        }
    }

}
