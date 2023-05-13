using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIStats : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo _playerInfo;
    [SerializeField]
    private PlayerHealthLogic _healthLogic;
    [SerializeField]
    private TextMeshProUGUI _coinCount;
    [SerializeField] 
    private TextMeshProUGUI _name;
    [SerializeField]
    private Image _healthBar;


    private void Start()
    {
        
        _name.text = _playerInfo.Nickname;
    }
    private void Update()
    {
        _healthBar.fillAmount = _healthLogic.CurrentHealth / _healthLogic.MaxHealth;
        _coinCount.text = _playerInfo.Coins.ToString();
    }
}
