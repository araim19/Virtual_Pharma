using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class autodeplacement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myRigidbody;
    float mySpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mySpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            myRigidbody.velocity = transform.forward * mySpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            myRigidbody.velocity = -transform.forward * mySpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the sprite about the Y axis in the positive direction
            myRigidbody.velocity = transform.right * mySpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate the sprite about the Y axis in the negative direction
             myRigidbody.velocity = -transform.right * mySpeed;
        }
    }
}
