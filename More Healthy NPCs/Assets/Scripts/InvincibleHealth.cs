using System;
using UnityEngine;

public class InvincibleHealth : MonoBehaviour, IHealth
{
    public event Action<float, float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    public void TakeDamage(int amount)
    {
        GetComponent<HPBar>().UpdateText("I'm Invincible!");
    }
}
