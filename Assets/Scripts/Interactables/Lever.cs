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
    [SerializeField] private GameObject[] objects;

    private void Awake()
    {
        On = false;
        Delay = 1f;
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
            foreach(GameObject obj in objects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject obj in objects)
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player" && Input.GetKey(KeyCode.E) && isReady)
        {
            On = !On;
            isReady = false;
        }
    }
}
