using UnityEngine;

public class BaseHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int startingHealth;

    private int currentHealth;
    private Knockback knockback;

    [SerializeField] private GameObject deathVFX;
    [SerializeField] private Transform deathVFXParent;

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

    public void Damage(int damage)
    {
        KnockbackController();
        currentHealth -= damage;
        DetectHeath();
    }

    private void KnockbackController()
    {
        if (canKnockable)
        {
            if (!knockback.CanBeKnocked)
                return;

            StartCoroutine(knockback.KnockbackCoroutine());
            knockback.GetKnockedBack(PlayerController.instance.transform);
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
