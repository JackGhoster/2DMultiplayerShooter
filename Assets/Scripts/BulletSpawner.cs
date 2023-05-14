using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private GameObject _bullet;
    private Button _shootButton;
    private PhotonView _view;
    private void Start()
    {
        _shootButton = GameObject.FindWithTag("ShootButton").GetComponent<Button>();
        _view = GetComponent<PhotonView>();
        if (_view.IsMine)
        {
            _shootButton.onClick.AddListener(Shoot);
        }
    }
    private void Shoot()
    {
        var bullet = PhotonNetwork.Instantiate(_bullet.name, _muzzle.position, _muzzle.rotation);
        bullet.GetComponent<Bullet>().enabled = true;
    }
}
