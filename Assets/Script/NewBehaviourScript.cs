using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;
    private List<Vector3> tails=new List<Vector3>();
    public Vector3 position;
    
   

    void Start()
    {
        GetNewPrefab();
    }


    void GetNewPrefab()
    {
        position = transform.position;
        Vector3 firstPositionTail = new Vector3 (position.x + 1, position.y, position.z + 1);
        print(position);
        print(firstPositionTail);
        
        for (int i = 0; i < 2; i++)
        {
            GameObject tail = new GameObject();
            tail = Instantiate(prefab);
            tail.transform.position = new Vector3 (firstPositionTail.x + i, firstPositionTail.y, firstPositionTail.z+i);
            print("������� �������" + tail.transform.position);
            tails.Add(tail.transform.position);
        }
    }

    

    private void Update()
    {
        
    }
}
