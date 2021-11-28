using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] int maxEnergy = 100;
    [SerializeField] int currentEnergy = 100;

    public void RecoverEnergy(int amount)
    {
        if (amount + currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        else
        {
            currentEnergy += amount;
        }
    }

    public void UseEnergy(int amount)
    {
        currentEnergy -= amount;

        if (currentEnergy <= 0)
        {
            Faint();
        }
    }

    public void Faint()
    {
        // Handle death
    }
}
