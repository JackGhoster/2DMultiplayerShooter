using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Linq;

/// <summary>
/// I am super exhausted today and 
/// I had very little time to work on this properly,
/// I know it's bad and might be buggy,sorry :)
/// </summary>
public class GameManager : MonoBehaviourPunCallbacks
{

    public static GameManager Instance { get; set; }
    public string WinnerName { get; private set; }

    public event Action OnStartGame;
    public event Action OnPlayerDied;
    public event Action OnWin;
 
    private float _waitingTime = 5f;
    private void Awake()
    {
        if (Instance == null ) Instance = this;

    }
    private void Start()
    {
        if (Instance == null) Instance = this;
        OnPlayerDied += CheckForWin;
        OnWin += WaitABitBeforeLeaving;
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            Invoke("StartGame", _waitingTime);
        }
    }
    [PunRPC]
    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();      
    }
    public void CheckForWin()
    {
        OnWin?.Invoke();
    }

    [PunRPC]
    private void StartGame()
    {
        OnStartGame?.Invoke();
    }
    private void WaitForGameToStart()
    {
        gameObject.GetComponent<PhotonView>().RPC("StartGame", RpcTarget.All);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                CancelInvoke("WaitForGameToStart");
                Invoke("WaitForGameToStart", _waitingTime);
            }
        }
    }
    private void WaitABitBeforeLeaving()
    {
        Invoke("LeaveGame", 2f);
    }
    private void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
    }


    public override void OnEnable()
    {
        base.OnEnable();
        if (Instance == null) Instance = this;
    }



}

