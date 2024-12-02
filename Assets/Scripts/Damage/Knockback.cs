using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Material defaultMat;
    private SpriteRenderer sr;

    [Header("Knockback")]
    [SerializeField] private float knockbackAmount;
    [SerializeField] private float knockedTime;
    public bool IsKnocked { get; private set; }
    public bool CanBeKnocked { get; private set; }

    [Header("Damage Flash")]
    [SerializeField] private Material whiteFlashMaterial;


    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        defaultMat = sr.material;
    }

    private void Start()
    {
        CanBeKnocked = true;
    }

    public void GetKnockedBack(Transform damageSource)
    {
        rb.velocity = Vector2.zero;
        Vector2 force = new Vector2(transform.position.x - damageSource.position.x , transform.position.y - damageSource.position.y).normalized * knockbackAmount;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public IEnumerator KnockbackCoroutine()
    {
        sr.material = whiteFlashMaterial;
        CanBeKnocked = false;
        IsKnocked = true;

        yield return new WaitForSeconds(knockedTime);

        sr.material = defaultMat;
        CanBeKnocked = true;
        IsKnocked = false;
    }

}
