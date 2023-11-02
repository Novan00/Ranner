using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacityEnemys;
    [SerializeField] private int _capacityAidKits;

    private List<GameObject> _pools = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacityAidKits; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pools.Add(spawned);
        }
    }

    protected void Initialize(GameObject[] prefabs, GameObject prefabAidKits)
    {
        for (int i = 0; i < _capacityEnemys; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.SetActive(false);

            _pools.Add(spawned);
        }

        for (int i = 0; i < _capacityAidKits; i++)
        {
            GameObject spawned = Instantiate(prefabAidKits, _container.transform);
            spawned.SetActive(false);

            _pools.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pools.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
