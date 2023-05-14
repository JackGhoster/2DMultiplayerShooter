using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ShootingFromPooler : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private Button _shootButton;
    private OnlineObjectPooler _pooler;
    private PhotonView _view;
    private void Start()
    {
        _pooler = GetComponent<OnlineObjectPooler>();
        _shootButton = GameObject.FindWithTag("ShootButton").GetComponent<Button>();
        _view = GetComponent<PhotonView>();
        if (_view.IsMine)
        {
            _shootButton.onClick.AddListener(Shoot);
        }
    }

    private void Shoot()
    {
        var bullet = _pooler.GetPooledObject();
        if(bullet != null )
        {
            bullet.transform.position = _muzzle.position;
            bullet.transform.rotation = _muzzle.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().enabled = true;
        }
    }

}
