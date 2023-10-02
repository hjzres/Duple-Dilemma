using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    [Header("win")]
    public bool win;
    [Header("players")]
    public string whichPlayer;
    public string otherPlayer;

    private void Awake()
    {
        win = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule 1")
        {
            whichPlayer = "Player 1";
            otherPlayer = "Player 2";
        }
        
        if (other.gameObject.name == "Capsule 2")
        {
            whichPlayer = "Player 2";
            otherPlayer = "Player 1";
        }

        win = true;
    }
}
