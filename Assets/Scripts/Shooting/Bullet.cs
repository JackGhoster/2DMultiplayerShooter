using UnityEngine;
using Photon.Pun;
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField, Range(10f, 100f)]
    private float _speed = 25f;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthLogic playerHealth = collision.GetComponent<PlayerHealthLogic>();
            playerHealth.GetComponent<PhotonView>().RPC("UpdateCurrentHealth", RpcTarget.AllBuffered, 1f,true);
            //playerHealth.UpdateCurrentHealth(1);
        }
        if (!collision.CompareTag("Coin")) this.enabled = false; 
    }
    private void OnEnable()
    {
        Invoke("TooLongInAir",2);
    }
    private void OnDisable()
    {
        //gameObject.SetActive(false);
        PhotonNetwork.Destroy(this.gameObject);
    }

    private void TooLongInAir()
    {
        this.enabled = false;
    }
}
