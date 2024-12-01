using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{

    public static ActiveWeapon instace;

    private PlayerControls playerControls;

    public MonoBehaviour CurrentActiveWeapon { get; set; }
    

    private bool isAttacking;
    public bool CanAttack { get; private set; } = true;

    private void Awake()
    {
        if (instace != null && instace != this.gameObject)
            Destroy(this);
        else
            instace = this;

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
        if (!PlayerController.instance.CanMove)
            return;

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
            IWeapon weapon = CurrentActiveWeapon.GetComponent<IWeapon>();
            weapon.Attack();
            StartCoroutine(AttackTimeCoroutine());
        }
    }

    private IEnumerator AttackTimeCoroutine()
    {
        CanAttack = false;

        IWeapon weapon = CurrentActiveWeapon.GetComponent<IWeapon>();
        float attackCooldown = weapon.GetWeapon().weaponCooldown;
        yield return new WaitForSeconds(attackCooldown);

        CanAttack = true;
    }


}
