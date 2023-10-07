using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Materials")]
    public Material NotPressed;
    public Material Pressed;

    public bool IsPressed;
    private Renderer renderer;

    [SerializeField] private int AmountOnPlate;
    [SerializeField] private GameObject GameManager;

    string[] tags = { "player", "obstacle" };

    private void Start()
    {
        IsPressed = false;
        renderer = GetComponent<Renderer>();
        renderer.material = NotPressed;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in tags)
        {
            if (other.gameObject.tag == tag)
            {
                AmountOnPlate++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (string tag in tags)
        {
            if (other.gameObject.tag == tag)
            {
                AmountOnPlate--;
            }
        }
    }

    private void Update()
    {
        isPressed();
    }

    private void isPressed()
    {
        if (AmountOnPlate > 0)
        {
            IsPressed = true;
            renderer.material = Pressed;
        }
        else
        {
            IsPressed = false;
            renderer.material = NotPressed;
        }
    }
}
