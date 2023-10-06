using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private bool collisionHandled = false;
    private bool collisionHandledTrap = false;
    private bool collisionHandledAve = false;
    private float dirX = -1f;
    private float moveSpeed = 3.7f;
    private Rigidbody2D rb;
    private int fishes = 0;

    [SerializeField] private GameObject key;
    [SerializeField] private GameObject map;
    [SerializeField] private TextMesh message;
    [SerializeField] private Text fishesText;
    [SerializeField] private Text keyText;
    [SerializeField] private Text mapText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private PlayerLife playerLife;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLife = GetComponent<PlayerLife>();
    }
    private void Update()
    {

        //Realiza una verificaci�n de colisi�n en cada fotograma
        Collider2D collider = GetComponent<Collider2D>();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.CompareTag("Maquina"))
            {
                SpriteRenderer spriteRenderer = col.gameObject.GetComponent<SpriteRenderer>();
                string spriteName = spriteRenderer.sprite.name;
                // Realiza acciones basadas en la colisi�n, por ejemplo:
                if (spriteName == "On (16x32)_0" || spriteName == "On (16x32)_1" || spriteName == "On (16x32)_2")
                {
                    rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
                    collisionHandled = true;
                }
                
            }
            else if (col.gameObject.CompareTag("Trap"))
            {
                rb.velocity = new Vector2(-20.0f * moveSpeed, rb.velocity.y);
                collisionHandledTrap = true;
            }

            else if (col.gameObject.CompareTag("Abismo"))
            {
                playerLife.restarVida();
                transform.position = new Vector3(-0.5f,-0.29f,0f); 
            }
            else if (col.gameObject.CompareTag("Ave"))
            {
                collisionHandledAve = true;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Maquina"))
        {
            if (collisionHandled) {
                collisionHandled = false;
                playerLife.restarVida();
            }
            
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (collisionHandledTrap)
            {
                collisionHandledTrap = false;
                playerLife.restarVida();
                GetComponent<RespawnManager>().ReaparecerPersonajeTrap();
            }
        }
        if (collision.gameObject.CompareTag("Ave"))
        {
            if (collisionHandledAve)
            {
                collisionHandledAve = false;
                playerLife.restarVida();
                GetComponent<RespawnManager>().ReaparecerPersonajeAve();


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
            
            if(fishes == 20)
            {
                playerLife.aumentarVida();
                fishes -= 20;
                fishesText.text = $"Pescados : {fishes}";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            mapText.text = $":1";
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            keyText.text = $":1";
        }
        else if (collision.gameObject.CompareTag("Final"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            map.GetComponent<SpriteRenderer>().enabled = true;
            key.GetComponent<SpriteRenderer>().enabled = true;
            message.GetComponent<MeshRenderer>().enabled = true;

            Rigidbody2D mapRigidbody = map.GetComponent<Rigidbody2D>();
            Rigidbody2D keyRigidbody = key.GetComponent<Rigidbody2D>();

            mapRigidbody.bodyType = RigidbodyType2D.Dynamic;
            keyRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{

    //    if (collision.gameObject.tag == "Maquina")
    //    {
    //        SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
    //        spriteMaquina = spriteRenderer.sprite.name;
    //        if (spriteMaquina == "On (16x32)_0" || spriteMaquina == "On (16x32)_1" || spriteMaquina == "On (16x32)_0")
    //        {
    //            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    //            playerLife.restarVida();
    //        }
    //    }

    //}

}
