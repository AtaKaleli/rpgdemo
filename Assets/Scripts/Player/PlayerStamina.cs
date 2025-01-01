using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private int staminaAmount = 3;

    private int currentStamina;



    private void Start()
    {
        currentStamina = staminaAmount;
    }

    private void IncreaseStamina()
    {
        currentStamina++;
    }

    private void DecreaseStamina()
    {
        currentStamina--;
    }
}
