using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    

    [Header("Magnet Information")]
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float accelerate = 1f;


    private void Update()
    {
        HandleAutoMagnet();
    }

    private void HandleAutoMagnet()
    {
        Vector3 playerPos = PlayerController.instance.transform.position;

        if (Vector2.Distance(playerPos, transform.position) < pickUpDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
            moveSpeed += accelerate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }

    

}
