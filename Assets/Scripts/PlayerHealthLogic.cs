using UnityEngine;
/// <summary>
/// Entire health logic. You can get CurrentHealth or MaxHealth from here for example.
/// </summary>
public class PlayerHealthLogic : MonoBehaviour
{
    private float _currentHealth;
    private float _maxHealth;
    public float CurrentHealth { get { return _currentHealth; }  }
    public float MaxHealth { get { return _maxHealth; } }

    private void Awake()
    {
        _maxHealth = 5f;
        UpdateCurrentHealth(value: _maxHealth, substractFromHealth: false);
    }

    /// <summary>
    /// Updates Current Health; By default subtracts value from hp;
    /// </summary>
    /// <param name="value">The amount by which the hp will change.</param>
    /// <param name="substractFromHealth">True by default; Set to false if you want to add the value to the hp. </param>
    public void UpdateCurrentHealth(float value, bool substractFromHealth = true)
    {
        if(substractFromHealth == false) _currentHealth += value;
        else _currentHealth -= value;
        print(CurrentHealth);
        Die();
    }

    private void Die()
    {
        if(_currentHealth == 0) 
        {
            Destroy(gameObject);
        }
    }
}
