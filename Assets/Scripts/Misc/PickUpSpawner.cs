using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private PickUpSO[] pickUps;

    private int pickUpIdx;


    private void Start()
    {
        pickUpIdx = RandomPickUpIndex();
    }

    public void Spawn()
    {
        int chance = Random.Range(0, 100);

        if (pickUps[pickUpIdx].spawnChance >= chance)
            Instantiate(pickUps[pickUpIdx].pickUpPref, transform.position, Quaternion.identity);

        
       
    }

    private int RandomPickUpIndex()
    {
        return Random.Range(0, pickUps.Length);
    }
}