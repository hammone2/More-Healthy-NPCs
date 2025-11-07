using System;
using System.Collections;
using UnityEngine;

public class DOTHealth : MonoBehaviour, IHealth
{
    public event Action<float, float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    [SerializeField] private float startingHealth = 100;
    private float currentHealth;
    [SerializeField] private float damageTime = 3f;
    private float currentDamagePerSecond;
    private bool canBeDamaged = true;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (canBeDamaged)
            return;

        currentHealth = Mathf.MoveTowards(currentHealth, 0f, currentDamagePerSecond * Time.deltaTime);
        OnHPPctChanged(currentHealth, startingHealth);

        if (currentHealth <= 0f)
        {
            OnDied();
        }
    }

    public void TakeDamage(int amount)
    {
        
        if (canBeDamaged)
        {
            currentDamagePerSecond = amount;
            StartCoroutine(DamageOverTime());
        }
    }

    private IEnumerator DamageOverTime()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(damageTime);
        canBeDamaged = true;
    }
}
