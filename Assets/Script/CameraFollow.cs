using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;
    public Vector3 PlatformToCAmeraOfSet;

    void Update()
    {
        Vector3 TargetPosition = target.transform.position + PlatformToCAmeraOfSet;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Time.deltaTime * smooth);
    }
}
