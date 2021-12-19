using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    private int quantityEat;


    void Start()
    {
        quantityEat = Random.Range(1, 11);
        print("Количество еды" + quantityEat);
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
}
