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
        GetNewPrefab();
    }


    void GetNewPrefab()
    {
        
        for (int i = 0; i < 2; i++)
        {
            tail = new GameObject();
            tail = Instantiate(prefab);
           // tail.transform.position = new Vector3 (firstPositionTail.x + i, firstPositionTail.y, firstPositionTail.z+i);
            print("Позиция префаба" + tail.transform.position);
            tails.Add(tail.transform.position);
        }
    }
    

    private void Update()
    {
        position = transform.position;
        firstPositionTail = new Vector3(position.x + 1, position.y, position.z + 1);
        print(position);
        print(firstPositionTail);

        for (int i = 0; i < 2; i++)
        {
            tail.transform.position = new Vector3(firstPositionTail.x + i, firstPositionTail.y, firstPositionTail.z + i);
            print("Позиция префаба" + tail.transform.position);
         
        }
    }
}
