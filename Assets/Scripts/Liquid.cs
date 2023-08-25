using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private string liquid;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameManager Manager;

    private void Awake()
    {
        Manager = GameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(liquid == "water")
        {
            if(other.gameObject.name == Manager.playerOne.name)
            {
                Manager.Death();
            }
        }
        if(liquid == "lava")
        {
            if(other.gameObject.name == Manager.playerTwo.name)
            {
                Manager.Death();
            }
        }
        if(liquid == "acid")
        {
            if(other.gameObject.name == Manager.playerOne.name || other.gameObject.name == Manager.playerTwo.name)
            {
                Manager.Death();
            }
        }

    }
}
