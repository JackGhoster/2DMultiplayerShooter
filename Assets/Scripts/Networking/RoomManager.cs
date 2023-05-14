using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private TMP_InputField _createInput, _joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
