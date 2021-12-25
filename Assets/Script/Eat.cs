using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public int quantityEat;
    public TextMesh TextMesh;


    void Start()
    {
        quantityEat = Random.Range(3, 6);
        //print("Количество еды" + quantityEat);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Snake snake))
        {
            for (int i = 0; i < quantityEat; i++)
            {
                snake.AddTails();
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        TextMesh.text = quantityEat.ToString();
    }

}

