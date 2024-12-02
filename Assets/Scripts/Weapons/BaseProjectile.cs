using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    protected Rigidbody2D rb;
    //protected WeaponSO weapon;
    protected SpriteRenderer sr;


    [Header("Projectile Settings")]
    [SerializeField] protected float projectileSpeed;
    protected Transform startPos;
    protected float projectileRange;



    [Header("Death VFX")]
    [SerializeField] protected GameObject deathVFX;



    public Vector2 ProjectileDirection { get; set; }
    public float ProjectileAngle { get; set; }




    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    protected virtual void Start()
    {
        SetProjectileRotation();

    }


    protected virtual void FixedUpdate()
    {
        DetectFireDistance();
        
    }

    public void UpdateProjectileRange(float range)
    {
        projectileRange = range;
    }

    protected virtual void SetProjectileRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, ProjectileAngle);
    }



    protected virtual void DetectFireDistance()
    {
        
        if (Vector2.Distance(transform.position, startPos.position) > projectileRange)
        {
            Destroy(this.gameObject);
        }
    }
}
