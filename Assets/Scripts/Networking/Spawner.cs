using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    [SerializeField, Range(-20, 20)]
    private float _minPosX = 0, _maxPosX = 0, _minPosY = 0, _maxPosY = 0;

    [SerializeField]
    private GameObject _playerPrefab, _gameManager;



    private void Start()
    {
        PhotonNetwork.Instantiate(_gameManager.name, transform.position, Quaternion.identity).GetComponent<GameManager>();
        GameManager.Instance = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        GameManager.Instance.OnStartGame += SpawnPlayers;
    }


    private void SpawnPlayers()
    {
        var randomX = Random.Range(_minPosX, _maxPosX);
        var randomY = Random.Range(_minPosY, _maxPosY);
        Vector2 randomPos = new Vector2(randomX, randomY);
        PhotonNetwork.Instantiate(_playerPrefab.name, randomPos, Quaternion.identity);
    }
    private void OnDisable()
    {
        GameManager.Instance.OnStartGame -= SpawnPlayers;
    }
}
