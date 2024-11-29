using UnityEngine;

public class Arrow : BaseProjectile
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ArrowMovement();
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
