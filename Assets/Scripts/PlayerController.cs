using UnityEngine;

/// <summary>
/// Moves player depending on the input from a virtual joystick. Requiers a reference to the virtual joystick!
/// </summary>
[RequireComponent (typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick _joystick;

    private Rigidbody2D _rigidbody;
    
    private float _moveSpeed = 5f;

    private void Awake()
    {
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var moveVector = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
        _rigidbody.velocity = moveVector;               
    }
}
