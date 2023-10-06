using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public float delay = 1;
    public bool isReady;

    public string whichPlayer;
    public string otherPlayer;

    [SerializeField] private GameObject GameManager;
    private GameManager Manager;

    [SerializeField] private GameObject holder;
    [SerializeField] private Text text;

    public string outcome;

    private void Start()
    {
        isReady = true;
        Manager = GameManager.GetComponent<GameManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player" && Input.GetKey(KeyCode.E) && isReady)
        { 
            isReady = false;
            results();
        }

        if (other.name == "Capsule 1")
        {
            whichPlayer = "Player 1";
            otherPlayer = "Player 2";
        }

        if (other.name == "Capsule 2")
        {
            whichPlayer = "Player 2";
            otherPlayer = "Player 1";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        whichPlayer = null;
        otherPlayer = null;
    }

    private void Update()
    {
        if (!isReady)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                isReady = true;
                delay = 1;
            }
        }

        float DistFromPlayerOne = Vector3.Distance(Manager.playerOne.transform.position, transform.position);
        float DistFromPlayerTwo = Vector3.Distance(Manager.playerTwo.transform.position, transform.position);

        if (DistFromPlayerOne < 10f || DistFromPlayerTwo < 10f)
        {
            holder.SetActive(true);
        }
        else
        {
            holder.SetActive(false);
        }

        text.text = outcome;
    }

    private void results()
    {
        switch (outcome)
        {
            case "swap":
                Manager.OtherSide();
                break;
            case "death":
                Manager.Death();
                break;
            case "freeze":
                Manager.Freeze(GameObject.Find(whichPlayer), true);
                break;
            case "unfreeze":
                Manager.Freeze(GameObject.Find(whichPlayer), false);
                break;
            case "freeze other":
                Manager.Freeze(GameObject.Find(otherPlayer), true);
                break;
            case "unfreeze other":
                Manager.Freeze(GameObject.Find(otherPlayer), false);
                break;
        }
    }
}
