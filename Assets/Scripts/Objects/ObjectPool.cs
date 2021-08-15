using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    public List<GameObject> Pool => _pool;

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);
        return result != null;
    }

    protected void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject poolObject = Instantiate(_template, _container.transform);
            poolObject.SetActive(false);

            _pool.Add(poolObject);
        }
    }
}
