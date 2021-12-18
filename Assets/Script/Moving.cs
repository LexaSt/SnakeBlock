using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    public float speed2;
    public float tailDstance;
    public Rigidbody Rigidbody;
    public GameObject TailPrefab;
    public int len;
    private List<Transform> tails= new List<Transform>();
    //private Transform _position;

    private void Start()
    {
        AddTailSanke();
 
    }
    private void Update()
    {
        moveTail();

        if (Input.GetKey("a"))
        {
            Rigidbody.velocity = new Vector3(0, 0, -speed);
        }

        else if (Input.GetKey("d"))
        {
            Rigidbody.velocity = new Vector3(0, 0, speed);
        }
        else if (Input.GetKey("w"))
        {
            Rigidbody.velocity = new Vector3(-speed, 0, 0);
        }
        else if (Input.GetKey("s"))
        {
            Rigidbody.velocity = new Vector3(speed, 0, 0);
        }

       
    }
    private void AddTailSanke()
    {
        for (int i = 0;  i < len; i++)
        {
            GameObject tail = Instantiate(TailPrefab);
            tails.Add(tail.transform);
        } 
    }


    private void moveTail()
    {
        float sqrDistance = tailDstance * tailDstance;
        Vector3 previosTail = transform.position;
        foreach (var tail in tails)
        {
            if ((tail.position - previosTail).sqrMagnitude > sqrDistance)
            {
                var temp = tail.position;
                tail.position = previosTail;
                previosTail = temp;
            }
            else 
            {
                break;
            }
        
        
        }


        //_position.position = newPosition;


    }
}
