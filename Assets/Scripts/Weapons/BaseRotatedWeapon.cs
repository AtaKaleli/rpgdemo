using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotatedWeapon : MonoBehaviour, IWeapon
{
    private SpriteRenderer sr;

    [Header("Weapon SO")]
    [SerializeField] private WeaponSO weapon;


    [Header("Rotation Information")]
    [SerializeField] private float weaponDistanceX = 1.0f;
    [SerializeField] private float weaponDistanceY = 0.25f;
    private Vector2 direction;
    private float angle;
    private bool isFacingRight = true;

    [Header("Projectile Information")]
    [SerializeField] private GameObject projectilePref;
    [SerializeField] private Transform projectileSpawnPoint;


    [Header("Weapon Recoil Informaton")]
    public Transform startPosition;
    public Transform movePosition;
    public float moveSpeed = 1f;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    protected virtual void Update()
    {
        HandleWeaponRotation();
        FlipController();
    }


    private void HandleWeaponRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - PlayerController.instance.transform.position.x, mousePos.y - PlayerController.instance.transform.position.y).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.SetPositionAndRotation(new Vector3(0, weaponDistanceY) + PlayerController.instance.transform.position + transform.rotation * new Vector2(weaponDistanceX, 0), Quaternion.Euler(0, 0, angle));
    }



    public void Attack()
    {

        GameObject newProjectile = Instantiate(projectilePref, projectileSpawnPoint.position, Quaternion.identity);

        newProjectile.GetComponent<BaseProjectile>().ProjectileDirection = direction;
        newProjectile.GetComponent<BaseProjectile>().ProjectileAngle = angle;
    }


    public WeaponSO GetWeapon()
    {
        return weapon;
    }

    private void FlipController()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        float distance = mouseWorldPos.x - transform.position.x;

        if ((distance < 0 && isFacingRight) || (distance > 0 && !isFacingRight))
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        sr.flipY = !sr.flipY;
    }
}
