using System.Collections;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator anim;
    private PlayerController playerController;

    [SerializeField] private GameObject slashVFX;
    [SerializeField] private Transform slashRespawnPoint;
    [SerializeField] private Transform slashRespawnParent;
    [SerializeField] private GameObject swordCollider;

    private GameObject slashAnim;

    [SerializeField] private float swordAttackCD;
    private bool isAttacking;
    private bool canAttack = true;


    private void Awake()
    {
        playerControls = new PlayerControls();
        anim = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
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
        if (isAttacking && canAttack)
        {
            anim.SetTrigger("attack");
            swordCollider.SetActive(true);
            InstantiateSlashVFX();
            StartCoroutine(AttackTimeCoroutine());
        }
    }

    private IEnumerator AttackTimeCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(swordAttackCD);
        canAttack = true;
    }



    private void InstantiateSlashVFX()
    {
        slashAnim = Instantiate(slashVFX, slashRespawnPoint.position, Quaternion.identity, slashRespawnParent);
    }

    public void SwingUpFlipAnimEvent()
    {
        if (playerController.IsFacingRight)
            slashAnim.transform.rotation = Quaternion.Euler(180, 0, 0);
        else
            slashAnim.transform.rotation = Quaternion.Euler(180, 180, 0);
    }

    public void SwingDownFlipAnimEvent()
    {
        if (playerController.IsFacingRight)
            slashAnim.transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            slashAnim.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    public void DisableSwordColliderAnimEvent()
    {
        swordCollider.SetActive(false);
    }

}
