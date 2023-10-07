using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ave : MonoBehaviour
{
    private float velocidad;
    private float limiteX1;
    private float limiteX2;
    private Vector2 direccion;
    private SpriteRenderer srAve;
    // Start is called before the first frame update
    void Start()
    {
        srAve = GetComponent<SpriteRenderer>();
    }
    public void crear(float x, float y, float vel, bool der, float limx1, float limx2)
    {
        int dir;
        transform.position = new Vector2(x, y);
        velocidad = vel;
        dir = (der == true ? 1 : -1);
        direccion = new Vector2(dir, 0);
        limiteX1 = limx1;
        limiteX2 = limx2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        if (transform.position.x > limiteX2 && direccion.x > 0)
        {
            srAve.flipX = false;
            direccion.x = -direccion.x;

        }
        if (transform.position.x < limiteX1 && direccion.x < 0)
        {
            srAve.flipX = true;
            direccion.x = -direccion.x;

        }
    }
}
