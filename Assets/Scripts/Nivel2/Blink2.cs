using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink2 : MonoBehaviour
{
    public float distanciaSubir = 2.0f; // Distancia que el objeto subir�.
    public float tiempoQuieto = 2.0f; // Tiempo en segundos que el objeto se quedar� quieto.
    public float velocidad = 2.0f; // Velocidad de movimiento.

    private Vector3 posicionOriginal; // Posici�n original del objeto.
    private bool subiendo = false; // Indica si el objeto est� subiendo.
    private float tiempoPasadoQuieto = 0.0f; // Tiempo transcurrido en el estado quieto.

    void Start()
    {
        posicionOriginal = transform.position; // Guarda la posici�n original.
    }

    void Update()
    {
        if (!subiendo)
        {
            // Mueve el objeto hacia arriba.
            float desplazamiento = velocidad * Time.deltaTime;
            transform.Translate(Vector3.up * desplazamiento);

            // Comprueba si el objeto ha subido la distancia deseada.
            if (transform.position.y >= posicionOriginal.y + distanciaSubir)
            {
                subiendo = true;
            }
        }
        else
        {
            // El objeto est� subido, espera el tiempo especificado.
            tiempoPasadoQuieto += Time.deltaTime;
            if (tiempoPasadoQuieto >= tiempoQuieto)
            {
                // El tiempo de espera ha terminado, mueve el objeto de regreso.
                float desplazamiento = velocidad * Time.deltaTime;
                transform.Translate(Vector3.down * desplazamiento);

                // Comprueba si el objeto ha vuelto a su posici�n original.
                if (transform.position.y <= posicionOriginal.y)
                {
                    // El objeto ha vuelto a su posici�n original.
                    subiendo = false;
                    tiempoPasadoQuieto = 0.0f; // Reinicia el contador de tiempo.
                }
            }
        }
    }
}
