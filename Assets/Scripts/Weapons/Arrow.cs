using UnityEngine;

public class Arrow : BaseProjectile
{
    private WeaponSO weapon;

    protected override void Awake()
    {
        base.Awake();
        weapon = ActiveWeapon.instace.CurrentActiveWeapon.GetComponent<IWeapon>().GetWeapon();
        startPos = ActiveWeapon.instace.transform;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ArrowMovement();
    }

    protected override void Start()
    {
        base.Start();
        projectileRange = weapon.weaponRange;
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
