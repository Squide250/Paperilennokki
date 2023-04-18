using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float roll;
    float pitch;
    public float responsiveness;
    float lift;
    public float liftModifier;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void GetInputs()
    {
        roll = -Input.GetAxis("Horizontal");
        pitch = -Input.GetAxis("Vertical");
    }

    void Update()
    {
        GetInputs();

        lift = rb.velocity.magnitude * liftModifier;
    }

    private void FixedUpdate()
    {

        //lift
        rb.AddForce(Vector3.up * 9.81f);


        //forwards speed
        transform.Translate(0, 0, speed);


        //rotation
        rb.AddTorque(transform.forward * roll * responsiveness);
        rb.AddTorque(transform.right * pitch * responsiveness);

    }
}
