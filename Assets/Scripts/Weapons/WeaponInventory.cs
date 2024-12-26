using UnityEngine;

public class WeaponInventory : MonoBehaviour
{

    private PlayerControls playerControls;

    private Transform weaponRespawnPoint;
    private Transform weaponRespawnParent;
    [SerializeField] private GameObject[] activeWeaponSlot;

    private int currentWeaponIdx = 0;
    private GameObject currentWeapon;

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
        if (weaponRespawnPoint == null && weaponRespawnParent == null)
        {
            weaponRespawnParent = ActiveWeapon.instace.transform;
            weaponRespawnPoint = ActiveWeapon.instace.transform;
        }

        playerControls.Inventory.Keyboard.started += ctx => ToggleActiveWeaponSlot((int)ctx.ReadValue<float>());
        InstantiateWeapon(0);
    }

    private void ToggleActiveWeaponSlot(int slotIdx)
    {
        if (currentWeaponIdx == slotIdx - 1) // if player tries to toggle active weapon slot or is attacking with any weapon, just dont allow toggling
            return;

        currentWeaponIdx = slotIdx - 1;
        for (int i = 0; i < activeWeaponSlot.Length; i++)
        {
            activeWeaponSlot[i].SetActive(false);
        }

        activeWeaponSlot[currentWeaponIdx].SetActive(true);
        ChangeActiveWeapon(currentWeaponIdx);
        ActiveWeapon.instace.StopAttacking();
    }

    private void ChangeActiveWeapon(int activeWeaponIdx)
    {
        Destroy(ActiveWeapon.instace.CurrentActiveWeapon.transform.parent.gameObject);
        InstantiateWeapon(activeWeaponIdx);
    }

    private void InstantiateWeapon(int activeWeaponIdx)
    {
        GameObject activeWeapon = transform.GetChild(activeWeaponIdx).GetComponent<InventorySlot>().GetWeapon().weaponPref;
        WeaponRotationController(activeWeapon);
        ActiveWeapon.instace.CurrentActiveWeapon = currentWeapon.GetComponentInChildren<MonoBehaviour>();
    }

    private void WeaponRotationController(GameObject activeWeapon)
    {
        if (!PlayerController.instance.IsFacingRight)
            currentWeapon = Instantiate(activeWeapon, weaponRespawnPoint.position, Quaternion.Euler(0, 180, 0), weaponRespawnParent);
        else
            currentWeapon = Instantiate(activeWeapon, weaponRespawnPoint.position, Quaternion.Euler(0, 0, 0), weaponRespawnParent);
    }

}
