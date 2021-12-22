using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject[] prefabBlock;
    public GameObject [] prefabEat;
    public GameObject firstBlock;
    public Transform level;
    public GameMenu GameMenu;
    public Moving Moving;
    [Range(1, 3)]
    public int levelIndex=1;
    //public Moving Moving;


    private void Awake()
    {
        levelIndex = GameMenu.LevelID+1;
        print(levelIndex);
    }

    private void Start()
    {
        GameObject first = Instantiate(firstBlock);
        first.transform.localPosition = new Vector3(2.747769f, -5.416524f, 30);

        if (levelIndex == 1) //30-230, step 10 = 20 prefab   -2.5f, 4f)
        {
            level.localScale = new Vector3(1, 1, 10);
            for (float i = 30; i <= 230; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 10 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }

                //Moving.speed = 10f;
            }
        }

        else if (levelIndex == 2) //30-460, step 10 = 43 prefab
        {
            level.localScale = new Vector3(1, 1, 20);
            for (float i = 30; i <= 460; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 10 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }
                //Moving.speed = 10f;
            }
        }
        else if (levelIndex == 3) //30-700, step 10 = 67 prefab
        {
            level.localScale = new Vector3(1, 1, 30);
            for (float i = 30; i <= 700; i += 10)
            {
                GameObject blocks = Instantiate(prefabBlock[Random.Range(0, prefabBlock.Length)]);
                blocks.transform.localPosition = new Vector3(2.747769f, -5.416524f, 10 + i);

                GameObject eats = Instantiate(prefabEat[Random.Range(0, prefabEat.Length)]);
                if (prefabEat[0])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-6.5f, 6.5f), 0f, -21f + i);
                }
                if (prefabEat[1])
                {
                    eats.transform.localPosition = new Vector3(Random.Range(-2.5f, 4f), 0f, -21f + i);
                }
                //Moving.speed = 10f;
            }
        }
        else
        {
            Moving.speed = 0;
            Moving.sensitivity = 0;
            Debug.Log("Game over");
        }
    }
}
