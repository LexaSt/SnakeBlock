using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject prefab;
    private List<Vector3> tails = new List<Vector3>();
    public List<Transform> snakeCircles = new List<Transform>();
    private Vector3 position;
    private Vector3 firstPositionTail;
    private GameObject tail;
    public GameObject HeadSnake;
    private float howMuchTails = 0;
    public TextMesh TextMesh;
    public GameObject ParticleSystemBreackBlock;
    public GameObject fireWork;


    void Start()
    {
        position = transform.position;
        tails.Add(position);
        firstPositionTail = new Vector3(position.x, position.y, position.z -1);
        //print(position);
        //print(firstPositionTail);
        GetNewPrefab();
    }


    void GetNewPrefab()
    {
        for (float i = 0; i < howMuchTails; i ++)
        {
            tail = Instantiate(prefab);
            tail.transform.position = new Vector3(firstPositionTail.x, firstPositionTail.y, firstPositionTail.z - i);
            //print("������� �������" + tail.transform.position);
            tails.Add(tail.transform.position);
            snakeCircles.Add(tail.transform);
        }
    }

    void movingTails()
    {
        float distance = ((Vector3)HeadSnake.transform.position - tails[0]).magnitude;
        if (distance > 1)
        {
            tails.Insert(0, HeadSnake.transform.position);
            tails.RemoveAt(tails.Count - 1);
            distance = -1;

            for (int i = 0; i < snakeCircles.Count; i++)
            {
                snakeCircles[i].position = Vector3.Lerp(tails[i + 1], tails[i], distance);
            }
        }
    }

    public void AddTails()
    {
        howMuchTails = 1;
        GetNewPrefab();
       // print("���������� �������: " + snakeCircles.Count);
    }
    public void DelTails()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        tails.RemoveAt(1);
        //print("���������� �������: " + snakeCircles.Count);
    }

    
    private void Update()
    {
        movingTails();
      
        TextMesh.text = (snakeCircles.Count).ToString();
    }

    public void DestroyBlock()
    {
        StartCoroutine(DestroyCorotune());
    }

    IEnumerator DestroyCorotune()
    {
        ParticleSystemBreackBlock.SetActive(!ParticleSystemBreackBlock.activeSelf);
        yield return new WaitForSeconds(0.5f);
        ParticleSystemBreackBlock.SetActive(!ParticleSystemBreackBlock.activeSelf);
    }


    public void GoFirework()
    {
        fireWork.SetActive(!fireWork.activeSelf);
    }
    

}

 
