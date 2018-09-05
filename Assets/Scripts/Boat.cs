using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Boat : MonoBehaviour {

    public float waterLevel = 0;
    public float waterMax = 2;
    public float waterDensity = 0.125f;
    public float downForce = 4;

    float forceFactor;
    Vector3 floatForce;
    Rigidbody rb;

    public float speed = 5;
    public float rotSpeed = 5;
    float rot = 0;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            //transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            rb.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            //transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
            rb.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey("a"))
        {
            rot += -rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            rot += rotSpeed * Time.deltaTime;
        }
        rot = Mathf.Clamp(rot, -.5f, .5f);
        this.transform.Rotate(0, rot, 0);
        rot = Mathf.MoveTowards(rot, 0, .3f * Time.deltaTime);


    }


    void FixedUpdate()
    {
        forceFactor = 1 - ((transform.position.y - waterLevel) / waterMax);

        if (forceFactor > 0)
        {
            floatForce = -Physics.gravity * rb.mass * (forceFactor - (rb.velocity.y * waterDensity));
            floatForce += new Vector3(0, -downForce * rb.mass, 0);
            rb.AddForceAtPosition(floatForce, -transform.position);
        }

        if (Input.GetKey("w"))
        {
            //transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            rb.AddForce(transform.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            //transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
            rb.AddForce(-transform.forward * speed);
        }
    }

}
