using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float pushSpeedMulplier = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Rigidbody boxRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 pushDirection = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z).normalized;
            Vector3 pushForce = pushDirection * playerRigidbody.velocity.magnitude * pushSpeedMulplier;

            boxRigidbody.AddForce(pushForce);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if the object with a tag "obstacle" enters the trigger and the player clicks the button "E" then the box will be pulled towards the player as he moves backwards
        if (other.gameObject.CompareTag("obstacle") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Test");
            Rigidbody boxRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 pullDirection = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z).normalized;
            Vector3 pullForce = pullDirection * playerRigidbody.velocity.magnitude * pushSpeedMulplier;

            boxRigidbody.AddForce(-pullForce);
        }
    }
}
