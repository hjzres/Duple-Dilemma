using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject Up;
    [SerializeField] private GameObject Down;
    [Header("Is on?")]
    [SerializeField] private bool On;
    [Header("Delay")]
    [SerializeField] private float Delay;
    [SerializeField] private bool isReady;
    [Header("Objects")]
    [SerializeField] private GameObject[] onOnOn;
    [SerializeField] private GameObject[] offOnOn;
    [SerializeField] private GameObject leftE, rightE;
    [Header("Objective")]
    public bool objectiveList;
    public int objectiveNumber;
    [Header("Other")]
    [SerializeField] private GameObject GameManager;
    private GameManager Manager;

    private void Awake()
    {
        On = false;
        Delay = 1f;
        isReady = true;
        Manager = GameManager.GetComponent<GameManager>();
    }

    private void turnOn()
    {
        if (On)
        {
            Down.SetActive(true);
            Up.SetActive(false);
        }
        else
        {
            Down.SetActive(false);
            Up.SetActive(true);
        }
    }

    private void Update()
    {
        turnOn();

        if (!isReady)
        {
            if (Delay > 0f)
            {
                Delay -= Time.deltaTime;
            } 
            else
            {
                isReady = true;
                Delay = 1f;
            }
        }

        if(On)
        {
            foreach(GameObject obj in onOnOn)
            {
                obj.SetActive(false);
            }

            foreach(GameObject obj in offOnOn)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject obj in onOnOn)
            {
                obj.SetActive(true);
            }

            foreach(GameObject obj in offOnOn)
            {
                obj.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player" && Input.GetKey(KeyCode.E) && isReady)
        {
            On = !On;
            isReady = false;
            if (objectiveList && Manager.section == objectiveNumber)
            {
                Manager.section += 1;
            }
        }

        if (other.name == "Capsule 1")
        {
            leftE.SetActive(true);
        }

        if (other.name == "Capsule 2")
        {
            rightE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        leftE.SetActive(false);
        rightE.SetActive(false);
    }
}
