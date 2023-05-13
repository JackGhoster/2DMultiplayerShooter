using UnityEngine;
/// <summary>
/// Updates score of the player who collides with the coin's collider
/// </summary>
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerInfo stats = collision.gameObject.GetComponent<PlayerInfo>();
            stats.UpdateCoinCount(value: 1);
            gameObject.SetActive(false);
        }
    }
}
