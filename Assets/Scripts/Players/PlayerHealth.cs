using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public event Action<int> HealthChanged;
    public event Action Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void TakeHeal()
    {
        if (_health < _maxHealth)
        {
            _health++;

            HealthChanged?.Invoke(_health);
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
