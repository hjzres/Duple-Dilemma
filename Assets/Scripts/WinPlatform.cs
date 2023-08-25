using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    public bool win;
    [SerializeField] private string whichPlayer;
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
        }
        if (other.gameObject.name == "Capsule 2")
        {
            whichPlayer = "Player 2";
        }

        Manager.Freeze(GameObject.Find(whichPlayer), true);

        win = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        whichPlayer = null;
    }

    private void Update()
    {
        
    }
}
