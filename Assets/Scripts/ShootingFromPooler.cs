using UnityEngine;
using UnityEngine.UI;

public class ShootingFromPooler : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;
    [SerializeField]
    private Button _shootButton;
    private ObjectPooler _pooler;
    private void Awake()
    {
        _pooler = GetComponent<ObjectPooler>();
        _shootButton = GameObject.FindWithTag("ShootButton").GetComponent<Button>();

        _shootButton.onClick.AddListener(Shoot);
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
