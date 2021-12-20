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
    public float sensitivity;

    public float bounceSpeed=50;
    public float bounceSide;


    public void MouseControl()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - previosMousePosition;
            player.transform.position = player.transform.position + new Vector3(delta.x * sensitivity,0,0);
            if (player.transform.position.x >= 7)
            { 
                player.transform.position = new Vector3(7f, 0, player.transform.position.z);
            }
            if (player.transform.position.x <= -7)
            {
                player.transform.position = new Vector3(-7f, 0, player.transform.position.z);
            }
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
