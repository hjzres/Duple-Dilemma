using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private string liquid;

    [SerializeField] private GameObject GameManager;
    private GameManager Manager;

    [SerializeField] GameObject playerOneCam, playerTwoCam; // Player Cams
    [SerializeField] GameObject waterSeeThrough, lavaSeeThrough; // liquid seethrough objects

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
        switch (liquid) 
        {
            case "water":
                if (other.gameObject.name == Manager.playerOne.name)
                {
                    Manager.Death(); 
                }
                if (other.gameObject.name == playerTwoCam.name)
                {   
                    waterSeeThrough.SetActive(true); 
                }
                break;
            case "lava":
                if (other.gameObject.name == Manager.playerTwo.name)
                {
                    Manager.Death(); 
                }
                if (other.gameObject.name == playerOneCam.name)
                {
                    lavaSeeThrough.SetActive(true); 
                }
                break;
            case "acid":
                if (other.gameObject.name == Manager.playerOne.name || other.gameObject.name == Manager.playerTwo.name)
                {
                    Manager.Death();
                }
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (liquid)
        {
            case "water":
                if (other.gameObject.name == playerTwoCam.name)
                {
                    waterSeeThrough.SetActive(false);
                }
                break;
            case "lava":
                if (other.gameObject.name == playerOneCam.name)
                {
                    lavaSeeThrough.SetActive(false);
                }
                break;
        }
    }
}
