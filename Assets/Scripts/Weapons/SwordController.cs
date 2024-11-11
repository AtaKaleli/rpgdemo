using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private PlayerControls playerControls;

    private Animator anim;


    private void Awake()
    {
        playerControls = new PlayerControls();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack(); 
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
    }


}
