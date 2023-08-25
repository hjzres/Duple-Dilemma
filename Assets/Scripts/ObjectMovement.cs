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
}
