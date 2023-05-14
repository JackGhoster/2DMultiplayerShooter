using Photon.Pun;
using UnityEngine;
/// <summary>
/// Entire health logic. You can get CurrentHealth or MaxHealth from here for example.
/// </summary>
public class PlayerHealthLogic : MonoBehaviourPunCallbacks, IPunObservable
{
    private float _currentHealth;
    private float _maxHealth;
    public float CurrentHealth { get { return _currentHealth; }  }
    public float MaxHealth { get { return _maxHealth; } }

    private void Awake()
    {
        _maxHealth = 5f;
        //UpdateCurrentHealth(value: _maxHealth, substractFromHealth: false);
        _currentHealth = _maxHealth;
    }

    /// <summary>
    /// Updates Current Health; By default subtracts value from hp;
    /// </summary>
    /// <param name = "value" > The amount by which the hp will change.</param>
    /// <param name = "substractFromHealth" > True by default; Set to false if you want to add the value to the hp. </param>
    [PunRPC]
    public void UpdateCurrentHealth(float value = 1, bool substractFromHealth = true)
    {
        if (substractFromHealth == false) _currentHealth += value;
        else _currentHealth -= value;
        TimeToDie();
    }

    private void TimeToDie()
    {
        if(_currentHealth == 0) 
        {
            GameManager.Instance.gameObject.GetComponent<PhotonView>().RPC("PlayerDied", RpcTarget.AllBuffered);
            if (gameObject.GetComponent<PhotonView>().IsMine)
            {
                
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(CurrentHealth);
        }
        else { 
            _currentHealth = (float)stream.ReceiveNext();
        }
    }

}
