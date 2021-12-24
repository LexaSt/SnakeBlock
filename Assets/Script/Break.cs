using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{

    private int liveBlock;
    public TextMesh TextMesh;
    public GameMenu game;
    public CameraFollow CameraFollow;
    public Moving Moving;

    void Start()
    {   
        liveBlock = Random.Range(4, 10);
        //print("������ � ����� � ������ " + liveBlock);

        game = FindObjectOfType<GameMenu>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (liveBlock > 0)
        {
            if (collision.collider.TryGetComponent(out Moving moving))
            {
                liveBlock -= 1;
                // print("������ � ����� " + liveBlock);
                moving.Bounce();
            }

            if (collision.collider.TryGetComponent(out Snake Snake))
            {
                if (Snake.snakeCircles.Count == 0)
                {
                    game.Over();
                 }
                else
                {
                    Snake.DelTails();
                }
            }    
        }
        else if (liveBlock == 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        TextMesh.text = liveBlock.ToString();
    }
}
