using UnityEngine;

[CreateAssetMenu(fileName = "New PickUp", menuName = "PickUp")]
public class PickUpSO : ScriptableObject
{
    public GameObject pickUpPref;
    public float spawnChance;
    
}
