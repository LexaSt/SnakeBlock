using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public float speed;
    public GameObject tailTarget;
    public Moving tail;

    private void Start()
    {

    }

    private void Update()
    {
        transform.LookAt(tailTarget.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
