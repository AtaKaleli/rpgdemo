using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool CanBeKnocked { get; private set; }
    public bool IsKnocked { get; private set; }

    [SerializeField] private float knockbackAmount;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CanBeKnocked = true;
    }

    public void GetKnockedBack(Transform damageSource)
    {
        Vector2 force = (transform.position - damageSource.position).normalized * knockbackAmount;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public IEnumerator KnockbackCoroutine()
    {
        CanBeKnocked = false;
        IsKnocked = true;

        yield return new WaitForSeconds(0.2f);

        CanBeKnocked = true;
        IsKnocked = false;
    }
}
