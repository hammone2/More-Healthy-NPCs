using System;
using System.Collections;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 5f;

    private int hitsRemaining;
    private bool canTakeDamage = true;

    public event Action<float, float> OnHPPctChanged = delegate (float f1, float f2) { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        hitsRemaining = healthInHits;
    }

    public void TakeDamage(int amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine(InvunlerabilityTimer());

            hitsRemaining--;

            OnHPPctChanged((float)hitsRemaining, (float)healthInHits);

            if (hitsRemaining <= 0)
                OnDied();
        }
    }

    private IEnumerator InvunlerabilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canTakeDamage = true;
    }
}