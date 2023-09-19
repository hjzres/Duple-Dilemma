using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    public bool win;
    public string whichPlayer;
    public string otherPlayer;
    [SerializeField] private GameObject gameManager;
    private GameManager Manager;

    private void Awake()
    {
        win = false;
        Manager = gameManager.GetComponent<GameManager>();
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

    private void Update()
    {
        
    }
}
