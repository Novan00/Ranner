using UnityEngine;

public class AidKitTrigger : MonoBehaviour
{
    [SerializeField] private AidKitLife _life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeHeal();
        }

        _life.Die();
    }
}

