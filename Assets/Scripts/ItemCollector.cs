using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fishes = 0;

    [SerializeField] private Text fishesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //prueba
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            fishes++;
            fishesText.text = $"Pescados : {fishes}";
        }
    }
}
