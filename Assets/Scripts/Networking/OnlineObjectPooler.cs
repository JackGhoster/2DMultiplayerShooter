using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
/// <summary>
/// Since classic Object Pooling doesnt work alright with photon pun, I made this versitZ
/// </summary>
public class OnlineObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField, Range(1,30)]
    private int _amountToPool = 10;
    private PhotonView _view;
    private List<GameObject> _pooledObjects = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        _view = GetComponent<PhotonView>();
        if (_view.IsMine)
        {
            //instantiates in a parent
            for (int i = 0; i < _amountToPool; i++)
            {
   
                GameObject obj = PhotonNetwork.Instantiate(_prefab.name, transform.position, transform.rotation);
                obj.SetActive(false);
                obj.transform.parent = transform;
                _pooledObjects.Add(obj);
            }
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
