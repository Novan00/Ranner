using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _secondsBetweenSpeedUp = 10;
    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpeedUp)
        {
            _elapsedTime = 0;
            _speed++;
        }

        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
