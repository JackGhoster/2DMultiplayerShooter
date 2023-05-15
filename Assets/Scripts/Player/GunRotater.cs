using UnityEngine;

/// <summary>
/// Rotates the gun this script attached to. Requiers a reference to the parent rigidbody.
/// </summary>
public class GunRotater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        if(_rigidbody.velocity != Vector2.zero)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg);
        }
        
    }
}
