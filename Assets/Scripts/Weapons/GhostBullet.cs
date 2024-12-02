using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBullet : BaseProjectile
{
    [SerializeField] private EnemySO enemy;

    protected override void Awake()
    {
        base.Awake();
        //startPos = 
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ArrowMovement();
    }

    protected override void Start()
    {
        base.Start();
        projectileRange = enemy.bulletRange;
        UpdateProjectileRange(projectileRange);
    }

    private void ArrowMovement()
    {
        rb.MovePosition(rb.position + ProjectileDirection * (projectileSpeed * Time.fixedDeltaTime));
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
