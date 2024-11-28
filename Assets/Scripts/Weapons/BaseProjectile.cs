using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private WeaponSO weapon;

    [Header("Projectile Settings")]
    [SerializeField] private float projectileSpeed;
    private Transform startPos;


    [Header("Death VFX")]
    [SerializeField] private GameObject deathVFX;



    public Vector2 ProjectileDirection { get; set; }
    public float ProjectileAngle { get; set; }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = ActiveWeapon.instace.CurrentActiveWeapon.GetComponent<IWeapon>().GetWeapon();
    }

    private void Start()
    {
        SetProjectileRotation();
        startPos = ActiveWeapon.instace.transform;
    }


    private void FixedUpdate()
    {
        DetectFireDistance();
        ProjectileMovement();
    }

    private void ProjectileMovement()
    {
        rb.MovePosition(rb.position + ProjectileDirection * (projectileSpeed * Time.fixedDeltaTime));
    }

    private void SetProjectileRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, ProjectileAngle);
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
        if (Vector2.Distance(transform.position, startPos.position) > weapon.weaponRange)
        {
            Destroy(this.gameObject);
        }
    }
}
