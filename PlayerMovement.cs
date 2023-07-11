using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 Movement;
    public float speed;
    private bool jumpKey;
    private bool isgrounded;
    // Update is called once per frame

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
        jumpKey = true;
       }
       Movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       Movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

    }
    private void LateUpdate()
    {
        transform.Translate(Movement, Space.Self);
        if(isgrounded != true)
        {
            return;
        }
        
        if (jumpKey)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*5,ForceMode.VelocityChange);
            jumpKey=false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isgrounded=true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isgrounded = false;
    }
}
