using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cierra : MonoBehaviour
{
    public float distanciaMaxima = 5.0f; // Distancia m�xima que el objeto se mover� de lado a lado.
    public float velocidad = 2.0f; // Velocidad de movimiento.

    private Vector3 puntoInicial; // Punto de inicio del movimiento.
    private bool moviendoseDerecha = true; // Indica si el objeto se est� moviendo hacia la derecha.

    void Start()
    {
        puntoInicial = transform.position; // Guarda la posici�n inicial.
    }

    void Update()
    {
        
        // Calcula el desplazamiento basado en la velocidad y la direcci�n.
        float desplazamiento = velocidad * Time.deltaTime;

        // Cambia la direcci�n si el objeto alcanza la distancia m�xima.
        if (transform.position.y >= puntoInicial.y + distanciaMaxima)
        {
            moviendoseDerecha = false;
        }
        else if (transform.position.y <= puntoInicial.y - distanciaMaxima)
        {
            moviendoseDerecha = true;
        }

        // Mueve el objeto en la direcci�n adecuada.
        if (moviendoseDerecha)
        {
            transform.Translate(Vector3.up * desplazamiento);
        }
        else
        {
            transform.Translate(Vector3.down * desplazamiento);
        }
    }
}
