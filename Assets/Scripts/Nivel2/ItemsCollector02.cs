using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemsCollector02 : MonoBehaviour
{
    private bool collisionHandledTrap = false;
    private bool collisionHandledCierra = false;
    private bool collisionHandledBlink = false;
    private float moveSpeed = 3.7f;
    private Rigidbody2D rb;
    private int fishes = 0;


    [SerializeField] private TextMesh message;
    [SerializeField] private Text fishesText;
    [SerializeField] private Text keyText;
    [SerializeField] private Text mapText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private PlayerFiles02 playerLife;
    private void Start()
    {
        playerLife = GetComponent<PlayerFiles02>();
        playerLife.lifes = PlayerPrefs.GetInt("Vidas");
        fishes = PlayerPrefs.GetInt("pescados");
        fishesText.text ="Pescado:  " + fishes.ToString();
        Debug.Log(PlayerPrefs.GetInt("pescados"));
        keyText.text = "0";
        mapText.text = "0";
        rb = GetComponent<Rigidbody2D>();
      
    }
    private void Update()
    {

        //Realiza una verificaci n de colisi n en cada fotograma
        Collider2D collider = GetComponent<Collider2D>();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.CompareTag("Trap"))
            {
                rb.velocity = new Vector2(-20.0f * moveSpeed, rb.velocity.y);
                collisionHandledTrap = true;
            }

            else if (col.gameObject.CompareTag("Abismo"))
            {
                playerLife.restarVida();
                transform.position = new Vector3(-0.5f, -0.29f, 0f);
            }
            else if (col.gameObject.CompareTag("Cierra"))
            {
                collisionHandledCierra = true;
            }
            else if (col.gameObject.CompareTag("Blink"))
            {
                collisionHandledBlink = true;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (collisionHandledTrap)
            {
                collisionHandledTrap = false;
                playerLife.restarVida();
            }
        }

        if (collision.gameObject.CompareTag("Cierra"))
        {
            if (collisionHandledCierra)
            {
                collisionHandledCierra = false;
                playerLife.restarVida();
                //GetComponent<RespawnManager>().ReaparecerPersonajeAve();
            }
        }
        if (collision.gameObject.CompareTag("Blink"))
        {
            if (collisionHandledBlink)
            {
                collisionHandledBlink = false;
                playerLife.restarVida();
                //GetComponent<RespawnManager>().ReaparecerPersonajeAve();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Fish"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            fishes++;
            fishesText.text = $"Pescados : {fishes}";
        }
        if (fishes == 20)
        {
            fishes = 0;
            playerLife.aumentarVida();
            fishesText.text = $"Pescados : {fishes}";
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Final"))
        {
            collectionSoundEffect.Play();
            message.GetComponent<MeshRenderer>().enabled = true;
            Destroy(collision.gameObject);

            Invoke("CargarEscena", 6.5f); 
        }
    }

    private void CargarEscena()
    {
        SceneManager.LoadScene("Continuara");
    }
}