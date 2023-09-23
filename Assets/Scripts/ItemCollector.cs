using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fishes = 0;

    [SerializeField] private TextMeshProUGUI fishesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //prueba
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            fishes++;
            fishesText.text = $"Pescados: {fishes}";
        }
    }
}
