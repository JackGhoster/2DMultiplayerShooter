using UnityEngine;

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
            playerHealth.UpdateCurrentHealth(1);
        }
        if (!collision.CompareTag("Coin")) this.enabled = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
