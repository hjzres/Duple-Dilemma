using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{

    [SerializeField] private GameObject[] pressureplates;
    private PressurePlate[] pp;
    [SerializeField] private StringBuilder amountPressed = new StringBuilder();
    private string expectedoutcome = "";

    private void Awake()
    {
        pp = new PressurePlate[pressureplates.Length];


        for(int i = 0; i < pressureplates.Length; i++)
        {
            pp[i] = pressureplates[i].GetComponent<PressurePlate>();
            amountPressed.Append("0");
            expectedoutcome += "1";
        }
        
        
    }

    private void Update()
    {
        for(int i = 0; i < pressureplates.Length; i++)
        {
            if (pp[i].IsPressed)
            {
                amountPressed[i] = '1';
            }
            else
            {
                amountPressed[i] = '0';
            }
        }

        if(amountPressed.Equals(expectedoutcome))
        {
            gameObject.SetActive(false);
        }
    }
    
}
