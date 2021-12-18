using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    private List<Vector3> tails=new List<Vector3>();
    public Vector3 position;
    public Vector3 firstPositionTail;
    public GameObject tail;



    void Start()
    {
        position = transform.position;
        firstPositionTail = new Vector3(position.x, position.y, position.z-0.5f);
        print(position);
        print(firstPositionTail);
        GetNewPrefab(); 
    }


    void GetNewPrefab()
    {
        for (float i = 0; i < 2; i=i+0.5f)
        {
            tail = new GameObject();
            tail = Instantiate(prefab);
            tail.transform.position = new Vector3 (firstPositionTail.x, firstPositionTail.y, firstPositionTail.z - i);
            print("Позиция префаба" + tail.transform.position);
            tails.Add(tail.transform.position);
        }
    }
    

    private void Update()
    {
        
       
    }
}
