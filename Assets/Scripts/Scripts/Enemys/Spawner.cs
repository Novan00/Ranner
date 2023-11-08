using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject _aidKitPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenspawn;

    private void Start()
    {
        Initialize(_enemyPrefabs, _aidKitPrefab);
        StartCoroutine(Spawn());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_secondsBetweenspawn);

        while (true)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }

            yield return delay;
        }
    }
}
