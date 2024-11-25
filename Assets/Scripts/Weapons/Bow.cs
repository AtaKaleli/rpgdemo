using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{

    [Header("Weapon SO")]
    [SerializeField] private WeaponSO weapon;


    [Header("Rotation Information")]
    [SerializeField] private float bowDistanceX = 1.0f;
    [SerializeField] private float bowDistanceY = 0.25f;
    private Vector2 direction;
    private float angle;

    [Header("Arrow Information")]
    [SerializeField] private GameObject arrowPref;
    [SerializeField] private Transform arrowSpawnPoint;


    [Header("Bow Recoil Informaton")]
    public Transform startPosition;
    public Transform movePosition;
    public float moveSpeed = 1f;




    private void Update()
    {

        HandleBowRotation();




    }


    private void HandleBowRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - PlayerController.instance.transform.position.x, mousePos.y - PlayerController.instance.transform.position.y).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.SetPositionAndRotation(new Vector3(0, bowDistanceY) + PlayerController.instance.transform.position + transform.rotation * new Vector2(bowDistanceX, 0), Quaternion.Euler(0, 0, angle));
    }



    public void Attack()
    {

        GameObject newArrow = Instantiate(arrowPref, arrowSpawnPoint.position, Quaternion.identity);

        newArrow.GetComponent<Arrow>().ArrowDirection = direction;
        newArrow.GetComponent<Arrow>().ArrowAngle = angle;
    }


    public WeaponSO GetWeapon()
    {
        return weapon;
    }

}
