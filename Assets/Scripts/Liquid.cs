using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private string liquid;
    [SerializeField] private GameObject GameManager;
    private GameManager Manager;
    [SerializeField] GameObject playerOneCam, playerTwoCam;
    [SerializeField] GameObject waterSeeThrough, lavaSeeThrough;

    private void Awake()
    {
        Manager = GameManager.GetComponent<GameManager>();
        if (liquid != "acid")
        {
            waterSeeThrough.SetActive(false);
            lavaSeeThrough.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(liquid == "water")
        {
            if(other.gameObject.name == Manager.playerOne.name)
            {
                Manager.Death();
            }
            if (other.gameObject.name == playerTwoCam.name)
            {
                waterSeeThrough.SetActive(true);
            }

        }
        if(liquid == "lava")
        {
            if(other.gameObject.name == Manager.playerTwo.name)
            {
                Manager.Death();
            }
            if(other.gameObject.name == playerOneCam.name)
            {
                lavaSeeThrough.SetActive(true);
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

    private void OnTriggerExit(Collider other)
    {
        if(liquid == "water")
        {
            if(other.gameObject.name == playerTwoCam.name)
            {
                waterSeeThrough.SetActive(false);
            }
        }
        if(liquid == "lava")
        {
            if(other.gameObject.name == playerOneCam.name)
            {
                lavaSeeThrough.SetActive(false);
            }
        }
    }
}
