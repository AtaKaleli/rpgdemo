using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : BaseHealth
{

    private Slider heathBar;



    protected override void Start()
    {
        base.Start();
        UpdateHealthBar();
    }

    protected override void Die()
    {
        //Player die and load scene will be added!
    }

    


    protected override void ReceiveDamage(Collider2D collision)
    {
        if(collision.GetComponent<EnemyDamageSource>() != null)
        {
            //extra logic "screen shake" will be implemented later on
            EnemyDamageSource enemyDamage = collision.GetComponent<EnemyDamageSource>();
            KnockbackController(enemyDamage.transform);
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        if (heathBar == null)
            heathBar = GameObject.Find("Health Slider").GetComponent<Slider>();

        heathBar.value = currentHealth;

    }
}
