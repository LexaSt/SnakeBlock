using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody player;
    private Vector3 previosMousePosition;

    public float speed;
    public float sensRotate;
    public float sensitivity=1f;

    public float bounceSpeed;


    public void MouseControl()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - previosMousePosition;
            player.AddForce(delta.x * sensitivity,0,0);
        }
        previosMousePosition = Input.mousePosition;
    
    
    }

    public void Bounce()
    {
        player.velocity = new Vector3(0 ,0, -bounceSpeed);
    }

    public void control()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * sensRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * sensRotate * Time.deltaTime);
        }
    }


    private void Update()
    {
        MouseControl();
        control();
        
    }
}
