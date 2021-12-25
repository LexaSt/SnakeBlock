using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[] prefabBlock;
    public GameObject[] prefabEat;
    public GameObject firstBlock;
    public GameObject secondBlock;
    public Transform level;
    public GameMenu GameMenu;
    public Moving Moving;
    [Range(1, 3)]
    public int levelIndex = 1;
    public Snake Snake;
    public int score;
    public GameObject AudioClip1;
    public GameObject AudioClip2;
    public GameObject AudioClip3;
    

    private void Awake()
    {
        levelIndex = GameMenu.LevelID + 1;
        //print(levelIndex);
       
    }

    private void Start()
    {
        GameObject first = Instantiate(firstBlock);
        first.transform.localPosition = new Vector3(2.747769f, -5.416524f, 30);
        GameObject second = Instantiate(secondBlock);
        second.transform.localPosition = new Vector3(2.747769f, -5.416524f, 40);

        if (levelIndex == 1) //30-230, step 10 = 20 prefab   -2.5f, 4f)
        {
            AudioClip1.SetActive(!AudioClip1.activeSelf);
            level.localScale = new Vector3(1, 1, 10);
            for (float i = 30; i <= 210; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 20 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }

                Moving.speed = 6f;
            }
        }

        else if (levelIndex == 2) //30-460, step 10 = 43 prefab
        {
            AudioClip2.SetActive(!AudioClip2.activeSelf);
            level.localScale = new Vector3(1, 1, 20);
            for (float i = 30; i <= 450; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 20 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }
                Moving.speed = 8f;
            }
        }
        else if (levelIndex == 3) //30-700, step 10 = 67 prefab
        {
            AudioClip3.SetActive(!AudioClip3.activeSelf);
            level.localScale = new Vector3(1, 1, 30);
            for (float i = 30; i <= 680; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 20 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }
                Moving.speed = 10f;
            }
        }
        else
        {
            Moving.speed = 0;
            Moving.sensitivity = 0;
            Destroy(first);
            Destroy(second);
            Debug.Log("Game over");
            GameMenu.LevelID = -1;
            GameMenu.AllLevelsScore = -GameMenu.scoreLevel;
            GameMenu.OnFinish();
        }
    }
    private void Update()
    {  
        score = Snake.snakeCircles.Count;
    }

    
}

