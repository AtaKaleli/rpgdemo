using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStaff : MonoBehaviour, IWeapon
{



    private void Update()
    {
        HandleMagicStaffRotation();
    }







    private void HandleMagicStaffRotation()
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
        print("attack with magic staff");
    }
}
