using UnityEngine;

public class BaseHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int startingHealth;

    private int currentHealth;
    private Knockback knockback;

    [SerializeField] private GameObject deathVFX;

    [SerializeField] private bool canKnockable;
    [SerializeField] private bool canDamageable;


    private void Awake()
    {
        if (canKnockable)
            knockback = GetComponent<Knockback>();
    }



    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void Damage(int damage, Transform damageSource)
    {
        KnockbackController(damageSource);
        currentHealth -= damage;
        DetectHeath();
    }

    private void KnockbackController(Transform damageSource)
    {
        if (canKnockable)
        {
            if (!knockback.CanBeKnocked)
                return;

            knockback.GetKnockedBack(damageSource);
            StartCoroutine(knockback.KnockbackCoroutine());
        }

    }

    private void DetectHeath()
    {
        if (canDamageable)
        {
            if (currentHealth <= 0)
            {
                Instantiate(deathVFX, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
