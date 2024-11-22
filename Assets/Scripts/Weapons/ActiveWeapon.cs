using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private PlayerControls playerControls;

    [SerializeField] private MonoBehaviour currentActiveWeapon;

    private bool isAttacking;
    public bool CanAttack { get; set; } = true;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        Attack();
    }


    private void StartAttacking()
    {
        isAttacking = true;
    }

    private void StopAttacking()
    {
        isAttacking = false;
    }

    private void Attack()
    {
        if(isAttacking && CanAttack)
        {
            IWeapon weapon = currentActiveWeapon.GetComponent<IWeapon>();
            weapon.Attack();
        }
    }


}
