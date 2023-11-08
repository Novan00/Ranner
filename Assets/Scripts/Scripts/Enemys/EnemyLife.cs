using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
