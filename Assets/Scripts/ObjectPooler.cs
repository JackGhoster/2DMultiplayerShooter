using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basic pooler that creates a bunch of objects in the hierarchy and sets them inactive upon instantiation.
/// Instantiates object in a parent
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField, Range(1,30)]
    private int _amountToPool = 10;

    private List<GameObject> _pooledObjects = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {

        //instantiates in a parent
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_prefab, transform);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }
    /// <summary>
    /// Allows to get an object from a object pooler!
    /// </summary>
    /// <returns>An object from a hierarchy if it's not active; Otherwise returns null.</returns>
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i] ;
            }
        }
        return null;
    }
}
