using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    // gets all the boxes and if any of them move then the sound effect will play
    public GameObject[] boxes;
    public SoundEffects soundEffect;
    public StringBuilder soundEffectData = new StringBuilder();
    public string soundEffectOff;
    private void Awake()
    {
        soundEffect = GameObject.Find("SoundEffect").GetComponent<SoundEffects>();
        boxes = GameObject.FindGameObjectsWithTag("obstacle");
        foreach(GameObject box in boxes)
        {
            soundEffectData.Append("0");
        }
        soundEffectOff = soundEffectData.ToString();
    }
    void Update()
    {
        
        for(int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].GetComponent<ObjectMovement>().IsMoving())
            {
                soundEffectData[i] = '1';
            }
            else
            {
                soundEffectData[i] = '0';
            }
        }

        soundEffect.isPushed = soundEffectData.ToString().Contains("1");

        /*if (soundEffectData.ToString().Equals(soundEffectOff))
        {
            soundEffect.isPushed = true;

            Debug.Log("test");
        } else
        {
            soundEffect.isPushed = false;
        }*/
        Debug.Log(soundEffectData.ToString());
    }

}
