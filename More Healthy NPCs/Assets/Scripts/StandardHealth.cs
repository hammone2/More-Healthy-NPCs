using System;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;

    public event Action<float, float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        OnHPPctChanged(currentHealth, startingHealth);

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        OnDied();
    }
}