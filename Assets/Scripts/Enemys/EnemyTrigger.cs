using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyLife _enemyLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_enemy.Damage);
        }

        _enemyLife.Die();
    }
}
