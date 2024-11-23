using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private float bowDistanceX = 1.0f;
    [SerializeField] private float bowDistanceY = 0.25f;









    private void Update()
    {
        HandleBowRotation();
    }







    private void HandleBowRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - PlayerController.instance.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.SetPositionAndRotation(new Vector3(0, bowDistanceY) + PlayerController.instance.transform.position + transform.rotation * new Vector2(bowDistanceX, 0), Quaternion.Euler(0, 0, angle));
    }



    public void Attack()
    {
        print("attacked with bow");
    }
}
