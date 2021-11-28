using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP = 100;

    public void Heal(int amount)
    {
        if (amount + currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else
        {
            currentHP = currentHP + amount;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Handle death
    }
}
