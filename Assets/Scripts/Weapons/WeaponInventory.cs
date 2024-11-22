using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    private PlayerControls playerControls;
    
    [SerializeField] private GameObject[] activeWeaponSlot;


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
        playerControls.Inventory.Keyboard.started += ctx => ToggleActiveWeaponSlot((int)ctx.ReadValue<float>());
    }

    private void ToggleActiveWeaponSlot(int slotIdx)
    {
        for (int i = 0; i < activeWeaponSlot.Length; i++)
        {
            activeWeaponSlot[i].SetActive(false);
        }

        activeWeaponSlot[slotIdx - 1].SetActive(true);
    }

}
