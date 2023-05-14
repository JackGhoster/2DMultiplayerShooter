using Photon.Pun;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    //Set boundaries here on in inspector
    [SerializeField]
    private GameObject _coin;
    [SerializeField, Range(1, 20)]
    private float _coinCount;
    [SerializeField, Range(-20, 20)]
    private float _minPosX = 0, _maxPosX = 0, _minPosY = 0, _maxPosY = 0;


    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameManager.Instance.OnStartGame += SpawnCoins;
        }
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _coinCount; i++)
        {
            var randomX = Random.Range(_minPosX, _maxPosX);
            var randomY = Random.Range(_minPosY, _maxPosY);
            Vector2 randomPos = new Vector2(randomX, randomY);
            PhotonNetwork.Instantiate(_coin.name, randomPos, Quaternion.identity);
        }
    }
}

