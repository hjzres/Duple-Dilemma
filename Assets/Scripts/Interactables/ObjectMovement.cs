using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] GameObject playerOne, playerTwo;
    public float pushingSpeed = 0.75f;
    public bool isPushing = false, isPulling = false;
    public SoundEffects soundEffect;

    private void Awake()
    {
        soundEffect = GameObject.Find("SoundEffect").GetComponent<SoundEffects>();
    }
    private void OnCollisionEnter(Collision other)
    {
        // this object will move when the player is touching it in the same direction the player is facing with the speed of the player's velocity multiplied by the push speed
        if (other.gameObject.tag == "player")

        {
            
            isPushing = true;
            transform.position += other.gameObject.GetComponent<Rigidbody>().velocity * pushingSpeed * Time.deltaTime;

        } 

    }

    private void Update()
    {
        //When the player is holding e and the player is 5 units away from the object, the object will move with the player in its direction
        if (Input.GetKey(KeyCode.E))
        {
            if (Vector3.Distance(playerOne.transform.position, transform.position) < 5f)
            {
                isPulling = true;
                // Calculate the direction vector from the object to the player
                Vector3 direction = (playerOne.transform.position - transform.position).normalized;

                // Move the object in the direction of the player
                transform.position += direction * Time.deltaTime * pushingSpeed;

                
            }
            if (Vector3.Distance(playerTwo.transform.position, transform.position) < 5f)
            {
                isPulling = true;
                // Calculate the direction vector from the object to the player
                Vector3 direction = (playerTwo.transform.position - transform.position).normalized;

                // Move the object in the direction of the player
                transform.position += direction * Time.deltaTime * pushingSpeed;

            }
        }
        else
        {
            isPulling = false;
        }

        // if the box is not moving, then the bool isMoving = false
        if (GetComponent<Rigidbody>().velocity.x == 0 && GetComponent<Rigidbody>().velocity.z == 0)
        {
            isPushing = false;
        }
        else
        {
            isPushing = true;
        }
    }

    public bool IsMoving()
    {
        if(isPushing || isPulling)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
