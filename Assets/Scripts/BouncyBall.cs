using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class should create a bouncy ball like affect (hopefully)
 * 
 * get velocity
 * get acceleration from velocity
 * get mass
 * get mass * acceleration = Force from ball
 * 
 * if object touched has no rigidbody
 * force away is proprtional to force of ball
 **/
public class BouncyBall : MonoBehaviour
{
    Rigidbody rb;
    Vector3 currentVelocity;
    bool calculatingCollision = false;

    [SerializeField]
    float bounceCoefficient = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentVelocity = rb.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!calculatingCollision)
        {
            //print("Updating Position");
            currentVelocity = rb.velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Starting Calculating Spring Force");
        if (collision.gameObject.GetComponent<Rigidbody>() == null)
        {
            ContactPoint contact = collision.GetContact(0);
            Vector3 direction = contact.normal;
            print(direction);
            float velocity = currentVelocity.magnitude;
            Vector3 reciprocalVelocity = direction * velocity * bounceCoefficient;
            rb.AddForceAtPosition(reciprocalVelocity, contact.point, ForceMode.VelocityChange);
        }
    }

    public void SetBounceCoefficient(float bounceCoeff)
    {
        bounceCoefficient = bounceCoeff;
    }
}
