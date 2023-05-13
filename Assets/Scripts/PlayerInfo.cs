using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// General Info about name of the player or about how many coins he collected!
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    private List<string> _basicNames = new List<string>()
    {
        "Appleman", "Rick", "Dragon", "Capoerista", "Duck", "Kira", "Toad", "Dude", "Master", "Newbie","Chad","Bot"
    };
    private int _coins = 0;

    public string Nickname { get; private set; }
    
    public int Coins { get { return _coins; } }
    
    private void Awake()
    {
        ChooseRandomName(addDigits: true);
    }

    

    /// <summary>
    /// Sets a random nickname from a list of basic nicknames!
    /// </summary>
    /// <param name="addDigits">Set to true if you want to add digits to the end of the nickname.</param>
    private void ChooseRandomName(bool addDigits = false)
    {
        Nickname = _basicNames[UnityEngine.Random.Range(0,_basicNames.Count)];
        
        if (addDigits == false) return;
        Nickname += UnityEngine.Random.Range(100, 999).ToString();
    }

    /// <summary>
    /// Updates Coins count; By default adds value to coins;
    /// </summary>
    /// <param name="value">The amount by which the coin amount will change.</param>
    /// <param name="substractCoins">True by default; Set to false if you want to subtract the value </param>
    public void UpdateCoinCount(int value, bool substractCoins = false)
    {
        if (substractCoins == false) _coins += value;
        else _coins -= value;
    }
}
