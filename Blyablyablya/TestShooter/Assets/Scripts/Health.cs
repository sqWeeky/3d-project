using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int m_Health;

    public event Action onDeath;

    public int CurrentHealth
    {
        get
        {
            return m_Health;
        }
        set
        {
            m_Health = value;
            if (m_Health <= 0)
                onDeath?.Invoke();
        }
    }

    public void SetDamage(int damage = 1)
    {
        CurrentHealth = CurrentHealth - damage;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
