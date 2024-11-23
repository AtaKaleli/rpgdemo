using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{

    private Animator anim;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    [Header("Slash Effect Information")]
    [SerializeField] private GameObject slashVFX;
    [SerializeField] private Transform slashRespawnPoint;
    [SerializeField] private GameObject swordCollider;

    private GameObject slashAnim;

    [Header("Sword Attack Information")]
    [SerializeField] private float swordAttackCD;

    


    private void Awake()
    {
        activeWeapon = ActiveWeapon.instace;
        anim = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        HandleSwordRotation();
    }

    private void HandleSwordRotation()
    {
        Vector3 mousePos = Input.mousePosition;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (PlayerController.instance.IsFacingRight)
            transform.parent.rotation = Quaternion.Euler(0, 0, angle);
        else
            transform.parent.rotation = Quaternion.Euler(0, 180, angle);
    }




    public void Attack()
    {

        anim.SetTrigger("attack");
        swordCollider.SetActive(true);
        InstantiateSlashVFX();
        StartCoroutine(AttackTimeCoroutine());

    }

    private IEnumerator AttackTimeCoroutine()
    {
        activeWeapon.CanAttack = false;
        yield return new WaitForSeconds(swordAttackCD);
        activeWeapon.CanAttack = true;
    }



    private void InstantiateSlashVFX()
    {
        slashAnim = Instantiate(slashVFX, slashRespawnPoint.position, Quaternion.identity, activeWeapon.transform.GetChild(0).transform);
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
