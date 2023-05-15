using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _waitingT,_wonT;

    private void Start()
    {
        Invoke("SubscribeToEvents", 1f);
    }
    private void SubscribeToEvents()
    {
        GameManager.Instance.OnStartGame += HideWaitingText;
        GameManager.Instance.OnWin += WaitABit;
    }
    private void HideWaitingText()
    {
       _waitingT.gameObject.SetActive(false);
    }

    private void WonText()
    {

        _wonT.gameObject.SetActive(true);
        var lastPlayer = GameObject.FindWithTag("Player");
        var coins = lastPlayer.GetComponent<PlayerInfo>().Coins;
        var name = lastPlayer.GetComponent<PlayerInfo>().Nickname;
        _wonT.text = $"{name} won! Coins: {coins}";

    }
    private void WaitABit()
    {
        Invoke("WonText", 0.5f);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnStartGame -= HideWaitingText;
        GameManager.Instance.OnWin -= WonText;
    }
}
