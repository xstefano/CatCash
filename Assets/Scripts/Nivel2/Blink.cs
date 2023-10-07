using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float distanciaBajar = 2.0f; // Distancia que el objeto bajar�.
    public float tiempoQuieto = 2.0f; // Tiempo en segundos que el objeto se quedar� quieto.
    public float velocidad = 2.0f; // Velocidad de movimiento.

    private Vector3 posicionOriginal; // Posici�n original del objeto.
    private bool bajando = false; // Indica si el objeto est� bajando.
    private float tiempoPasadoQuieto = 0.0f; // Tiempo transcurrido en el estado quieto.

    void Start()
    {
        posicionOriginal = transform.position; // Guarda la posici�n original.
    }

    void Update()
    {
        if (!bajando)
        {
            // Mueve el objeto hacia abajo.
            float desplazamiento = velocidad * Time.deltaTime;
            transform.Translate(Vector3.down * desplazamiento);

            // Comprueba si el objeto ha bajado la distancia deseada.
            if (transform.position.y <= posicionOriginal.y - distanciaBajar)
            {
                bajando = true;
            }
        }
        else
        {
            // El objeto est� bajado, espera el tiempo especificado.
            tiempoPasadoQuieto += Time.deltaTime;
            if (tiempoPasadoQuieto >= tiempoQuieto)
            {
                // El tiempo de espera ha terminado, mueve el objeto de regreso.
                float desplazamiento = velocidad * Time.deltaTime;
                transform.Translate(Vector3.up * desplazamiento);

                // Comprueba si el objeto ha vuelto a su posici�n original.
                if (transform.position.y >= posicionOriginal.y)
                {
                    // El objeto ha vuelto a su posici�n original.
                    bajando = false;
                    tiempoPasadoQuieto = 0.0f; // Reinicia el contador de tiempo.
                }
            }
        }
    }
}
