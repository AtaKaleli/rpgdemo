using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MagicStaff : MonoBehaviour, IWeapon
{

    private SpriteRenderer sr;

    [Header("Weapon SO")]
    [SerializeField] private WeaponSO weapon;

    [Header("Laser Information")]
    [SerializeField] private GameObject laserPref;
    [SerializeField] private Transform laserSpawnPoint;

    [Header("Rotation Information")]
    [SerializeField] private float bowDistanceX = 1.0f;
    [SerializeField] private float bowDistanceY = 0.25f;
    private Vector3 mousePos;
    private Vector2 direction;
    private float angle;
    private bool isFacingRight = true;




    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

    }


    private void Update()
    {
        HandleMagicStaffRotation();
        FlipController();
    }







    private void HandleMagicStaffRotation()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - PlayerController.instance.transform.position.x, mousePos.y - PlayerController.instance.transform.position.y).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.SetPositionAndRotation(new Vector3(0, bowDistanceY) + PlayerController.instance.transform.position + transform.rotation * new Vector2(bowDistanceX, 0), Quaternion.Euler(0, 0, angle));
    }

    public void Attack()
    {

        GameObject newLaser = Instantiate(laserPref, laserSpawnPoint.position, Quaternion.identity);
        newLaser.GetComponent<Laser>().ArrowDirection = direction;
        newLaser.GetComponent<Laser>().ArrowAngle = angle;

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
