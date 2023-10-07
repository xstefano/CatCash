using UnityEngine;

public class Raton : MonoBehaviour
{
    public float velocidad = 5.2f;
    public float limiteX = 4.1f;

    public SpriteRenderer spriteRenderer;
    public GameObject raton;

    public static bool debeMoverse = false;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (debeMoverse)
        {
            float direccion = limiteX > transform.position.x ? 1f : -1f;

            float nuevaPosicionX = transform.position.x + (direccion * velocidad * Time.deltaTime);
            nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, Mathf.Min(transform.position.x, limiteX), Mathf.Max(transform.position.x, limiteX));
            Vector3 nuevaPosicion = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
            transform.position = nuevaPosicion;

            if (transform.position.x == limiteX)
            {
                raton.GetComponent<Animator>().enabled = false;
                transform.position = new Vector3(38.85f, 0.1f, 0f);
                spriteRenderer.flipX = true;
                debeMoverse = false;
            }
        }
    }
}